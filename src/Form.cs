using CompilerTools.ROPGadgetFinder.Structs;
using CompilerTools.ROPGadgetFinder;
using System.Text.Json;
using Gee.External.Capstone.X86;
using ROPGadgetFinder.Structs;
using ROPGadgetFinder.JsonConverter;
using System.Text.Encodings.Web;

namespace ROPGadgetFinder
{
    public partial class Form : System.Windows.Forms.Form
    {
        private readonly string _instructionPatternsPath = Path.Combine(Directory.GetCurrentDirectory(), "pattern.json");
        private readonly JsonSerializerOptions _jsonOptions = new JsonSerializerOptions
        {
            Converters = { new X86InstructionConverter(), new LongToHexConverter() },
            WriteIndented = true,
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping //https://github.com/dotnet/runtime/issues/50998
        };

        private List<Gadget> _gadgets = new List<Gadget>();
        private List<InstructionPattern> _instructionPatterns = new();

        public Form()
        {
            InitializeComponent();
        }

        private void Form_Load(object sender, EventArgs e)
        {
            if(File.Exists(_instructionPatternsPath))
                _instructionPatterns = JsonSerializer.Deserialize<List<InstructionPattern>>(File.ReadAllText(_instructionPatternsPath), _jsonOptions) ?? new();

            if (_instructionPatterns.Count > 0)
            {
                foreach (var pattern in _instructionPatterns)
                    listBoxInstructionPatterns.Items.Add(pattern);
            }

            Dissassembler.logger = UpdateLabelThreadSafe;
        }

        private void Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            File.WriteAllText(_instructionPatternsPath, JsonSerializer.Serialize(_instructionPatterns, _jsonOptions));
        }

        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    // Set the folder path (user can edit to add wildcards manually)
                    textBoxPath.Text = folderDialog.SelectedPath;
                }
            }
        }

        private void buttonLoadExecutables_Click(object sender, EventArgs e)
        {
            try
            {
                string path = textBoxPath.Text;
                if (string.IsNullOrWhiteSpace(path))
                {
                    MessageBox.Show("Please enter a valid path.", "Invalid Path", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Task.Run(() =>
                {
                    // Calls your Dissassembler class to load the binaries.
                    Dissassembler.LoadBinaries(path);

                    var nodes = new List<TreeNode>();
                    var groupedBinaries = Dissassembler.executables.GroupBy(g => g.Path);

                    foreach (var group in groupedBinaries)
                    {
                        // Create a root node using the file name.
                        TreeNode fileNode = new TreeNode(Path.GetFileName(group.Key))
                        {
                            Tag = group.Key  // Store the full path if needed.
                        };

                        nodes.Add(fileNode);
                    }

                    UpdateResultTreeThreadSafe(nodes);
                    UpdateLabelThreadSafe($"Loaded {groupedBinaries.Count()} binaries...");
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading binaries: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonScanExecutables_Click(object sender, EventArgs e)
        {
            try
            {
                if (_instructionPatterns.Count == 0)
                {
                    MessageBox.Show("Please add at least one instruction pattern before scanning.", "No Pattern", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Task.Run(() =>
                {
                    _gadgets = Dissassembler.ScanExecutables(_instructionPatterns);
                    MessageBox.Show($"Search completed\nFound {_gadgets.Count} gadgets", "Scan Completed", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    var nodes = new List<TreeNode>();

                    var groupedGadgets = _gadgets.GroupBy(g => g.Binary.Path);
                    foreach (var group in groupedGadgets)
                    {
                        TreeNode fileNode = new TreeNode(Path.GetFileName(group.Key))
                        {
                            Tag = group.Key
                        };

                        foreach (var gadget in group)
                        {
                            string gadgetInfo = $"VA: {gadget.VirtualAddress.ToString("X8")} ({gadget.Instructions.Count} instructions)";
                            TreeNode gadgetNode = new TreeNode(gadgetInfo)
                            {
                                Tag = gadget
                            };
                            fileNode.Nodes.Add(gadgetNode);
                        }

                        nodes.Add(fileNode);
                    }

                    UpdateResultTreeThreadSafe(nodes);
                    UpdateLabelThreadSafe($"Found gadgets in {groupedGadgets.Count()} binaries...");
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error scanning binaries: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void buttonSaveResultToFile_Click(object sender, EventArgs e)
        {
            List<SerializableGadgetGroup> gadgetGroups
                = _gadgets.GroupBy(g => g.Binary.Path).Select(g => new SerializableGadgetGroup(g)).ToList();

            string json = JsonSerializer.Serialize(gadgetGroups, _jsonOptions);

            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "JSON Files (*.json)|*.json|All Files (*.*)|*.*";
                saveFileDialog.Title = "Save TreeView as JSON";
                saveFileDialog.DefaultExt = "json";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllText(saveFileDialog.FileName, json);
                    UpdateLabelThreadSafe($"Successfully exported the results to {Path.GetFileName(saveFileDialog.FileName)}");
                }
            }
        }

        #region Instruction Pattern Buttons

        private void buttonAddInstructionPattern_Click(object sender, EventArgs e)
        {
            using (AddPatternForm addForm = new AddPatternForm())
            {
                if (addForm.ShowDialog() == DialogResult.OK)
                {
                    InstructionPattern newPattern = addForm.Pattern;
                    _instructionPatterns.Add(newPattern);
                    listBoxInstructionPatterns.Items.Add(newPattern);
                }
            }
        }

        private void buttonRemoveInstructionPattern_Click(object sender, EventArgs e)
        {
            if (listBoxInstructionPatterns.SelectedIndex == -1)
                return;

            InstructionPattern selectedItem = (InstructionPattern)listBoxInstructionPatterns.SelectedItem!;
            _instructionPatterns.Remove(selectedItem);
            listBoxInstructionPatterns.Items.Remove(selectedItem);
        }

        private void buttonMoveUpInstructionPattern_Click(object sender, EventArgs e)
        {
            if (listBoxInstructionPatterns.SelectedIndex == -1 || listBoxInstructionPatterns.SelectedIndex == 0)
                return;

            _instructionPatterns.MoveUp(listBoxInstructionPatterns.SelectedIndex);
            listBoxInstructionPatterns.Items.MoveUp(listBoxInstructionPatterns.SelectedIndex);

            listBoxInstructionPatterns.SelectedIndex--;
        }

        private void buttonMoveDownInstructionPattern_Click(object sender, EventArgs e)
        {
            if (listBoxInstructionPatterns.SelectedIndex == -1 || listBoxInstructionPatterns.SelectedIndex == listBoxInstructionPatterns.Items.Count - 1)
                return;

            _instructionPatterns.MoveDown(listBoxInstructionPatterns.SelectedIndex);
            listBoxInstructionPatterns.Items.MoveDown(listBoxInstructionPatterns.SelectedIndex);

            listBoxInstructionPatterns.SelectedIndex++;
        }

        #endregion

        private void UpdateLabelThreadSafe(string text)
        {
            if (labelStatus.InvokeRequired)
            {
                labelStatus.Invoke((MethodInvoker)delegate
                {
                    labelStatus.Text = text;
                });
            }
            else
            {
                labelStatus.Text = text;
            }
        }

        private void UpdateResultTreeThreadSafe(List<TreeNode> nodes)
        {
            if (treeViewResults.InvokeRequired)
            {
                treeViewResults.Invoke((MethodInvoker)delegate
                {
                    treeViewResults.Nodes.Clear();
                    treeViewResults.Nodes.AddRange(nodes.ToArray());
                });
            }
            else
            {
                treeViewResults.Nodes.Clear();
                treeViewResults.Nodes.AddRange(nodes.ToArray());
            }
        }
    }
}
