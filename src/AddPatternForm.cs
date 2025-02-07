using CompilerTools.ROPGadgetFinder.Structs;
using Gee.External.Capstone.X86;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ROPGadgetFinder
{
    public partial class AddPatternForm : System.Windows.Forms.Form
    {
        public InstructionPattern Pattern { get; private set; }

        public AddPatternForm()
        {
            InitializeComponent();

            var sortedInstructionIds = Enum.GetValues(typeof(X86InstructionId))
                                           .Cast<X86InstructionId>()
                                           .OrderBy(id => id.ToString())
                                           .Skip(1)
                                           .ToList();

            comboBoxInstructionId.DataSource = sortedInstructionIds;

            var sortedRegisterIds = Enum.GetValues(typeof(X86RegisterId))
                                        .Cast<X86RegisterId>()
                                        .OrderBy(reg => reg.ToString())
                                        .Skip(1)
                                        .ToList();

            checkedListBoxReadRegisters.Items.AddRange(sortedRegisterIds.Cast<object>().ToArray());
            checkedListBoxWrittenRegisters.Items.AddRange(sortedRegisterIds.Cast<object>().ToArray());
        }

        private void checkBoxReadRegisters_CheckedChanged(object sender, EventArgs e)
        {
            checkedListBoxReadRegisters.Enabled = checkBoxReadRegisters.Checked;
        }

        private void checkBoxReadRegistersCount_CheckedChanged(object sender, EventArgs e)
        {
            numericUpDownReadRegistersLength.Enabled = checkBoxReadRegistersCount.Checked;
        }
        
        private void checkBoxWrittenRegisters_CheckedChanged(object sender, EventArgs e)
        {
            checkedListBoxWrittenRegisters.Enabled = checkBoxWrittenRegisters.Checked;
        }

        private void checkBoxWrittenRegistersCount_CheckedChanged(object sender, EventArgs e)
        {
            numericUpDownWrittenRegistersLength.Enabled = checkBoxWrittenRegistersCount.Checked;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            try
            {
                var pattern = new InstructionPattern
                {
                    id = (X86InstructionId)comboBoxInstructionId.SelectedItem
                };

                if (checkBoxReadRegistersCount.Checked)
                {
                    pattern.ExplicitlyReadRegistersCount = (int)numericUpDownReadRegistersLength.Value;
                }

                if (checkBoxReadRegisters.Checked)
                {
                    List<X86RegisterId> selectedRegisters = new List<X86RegisterId>();
                    foreach (var item in checkedListBoxReadRegisters.CheckedItems)
                    {
                        selectedRegisters.Add((X86RegisterId)item);
                    }
                    if (selectedRegisters.Any())
                    {
                        pattern.ExplicitlyReadRegisters = selectedRegisters;
                    }
                }

                if (checkBoxWrittenRegistersCount.Checked)
                {
                    pattern.ExplicitlyWrittenRegistersCount = (int)numericUpDownWrittenRegistersLength.Value;
                }

                if (checkBoxWrittenRegisters.Checked)
                {
                    List<X86RegisterId> selectedRegisters = new List<X86RegisterId>();
                    foreach (var item in checkedListBoxWrittenRegisters.CheckedItems)
                    {
                        selectedRegisters.Add((X86RegisterId)item);
                    }
                    if (selectedRegisters.Any())
                    {
                        pattern.ExplicitlyWrittenRegisters = selectedRegisters;
                    }
                }

                Pattern = pattern;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error creating pattern: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
