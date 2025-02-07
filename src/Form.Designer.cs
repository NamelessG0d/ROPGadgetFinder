namespace ROPGadgetFinder
{
    partial class Form
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form));
            labelPath = new Label();
            textBoxPath = new TextBox();
            buttonBrowse = new Button();
            buttonLoadExecutables = new Button();
            buttonScanExecutables = new Button();
            groupBoxInstructionPattern = new GroupBox();
            buttonMoveDownInstructionPattern = new Button();
            buttonMoveUpInstructionPattern = new Button();
            buttonRemoveInstructionPattern = new Button();
            listBoxInstructionPatterns = new ListBox();
            buttonAddInstructionPattern = new Button();
            treeViewResults = new TreeView();
            labelStatus = new Label();
            buttonSaveResultToFile = new Button();
            groupBoxInstructionPattern.SuspendLayout();
            SuspendLayout();
            // 
            // labelPath
            // 
            labelPath.AutoSize = true;
            labelPath.Location = new Point(14, 17);
            labelPath.Margin = new Padding(4, 0, 4, 0);
            labelPath.Name = "labelPath";
            labelPath.Size = new Size(34, 15);
            labelPath.TabIndex = 0;
            labelPath.Text = "Path:";
            // 
            // textBoxPath
            // 
            textBoxPath.Location = new Point(58, 14);
            textBoxPath.Margin = new Padding(4, 3, 4, 3);
            textBoxPath.Name = "textBoxPath";
            textBoxPath.Size = new Size(466, 23);
            textBoxPath.TabIndex = 1;
            textBoxPath.Text = "C:\\Windows\\System32\\*.dll";
            // 
            // buttonBrowse
            // 
            buttonBrowse.Location = new Point(537, 12);
            buttonBrowse.Margin = new Padding(4, 3, 4, 3);
            buttonBrowse.Name = "buttonBrowse";
            buttonBrowse.Size = new Size(88, 27);
            buttonBrowse.TabIndex = 2;
            buttonBrowse.Text = "Browse...";
            buttonBrowse.UseVisualStyleBackColor = true;
            buttonBrowse.Click += buttonBrowse_Click;
            // 
            // buttonLoadExecutables
            // 
            buttonLoadExecutables.Location = new Point(37, 58);
            buttonLoadExecutables.Margin = new Padding(4, 3, 4, 3);
            buttonLoadExecutables.Name = "buttonLoadExecutables";
            buttonLoadExecutables.Size = new Size(175, 27);
            buttonLoadExecutables.TabIndex = 3;
            buttonLoadExecutables.Text = "Load Executables";
            buttonLoadExecutables.UseVisualStyleBackColor = true;
            buttonLoadExecutables.Click += buttonLoadExecutables_Click;
            // 
            // buttonScanExecutables
            // 
            buttonScanExecutables.Location = new Point(233, 58);
            buttonScanExecutables.Margin = new Padding(4, 3, 4, 3);
            buttonScanExecutables.Name = "buttonScanExecutables";
            buttonScanExecutables.Size = new Size(175, 27);
            buttonScanExecutables.TabIndex = 4;
            buttonScanExecutables.Text = "Scan Executables";
            buttonScanExecutables.UseVisualStyleBackColor = true;
            buttonScanExecutables.Click += buttonScanExecutables_Click;
            // 
            // groupBoxInstructionPattern
            // 
            groupBoxInstructionPattern.Controls.Add(buttonMoveDownInstructionPattern);
            groupBoxInstructionPattern.Controls.Add(buttonMoveUpInstructionPattern);
            groupBoxInstructionPattern.Controls.Add(buttonRemoveInstructionPattern);
            groupBoxInstructionPattern.Controls.Add(listBoxInstructionPatterns);
            groupBoxInstructionPattern.Controls.Add(buttonAddInstructionPattern);
            groupBoxInstructionPattern.Location = new Point(14, 104);
            groupBoxInstructionPattern.Margin = new Padding(4, 3, 4, 3);
            groupBoxInstructionPattern.Name = "groupBoxInstructionPattern";
            groupBoxInstructionPattern.Padding = new Padding(4, 3, 4, 3);
            groupBoxInstructionPattern.Size = new Size(610, 173);
            groupBoxInstructionPattern.TabIndex = 5;
            groupBoxInstructionPattern.TabStop = false;
            groupBoxInstructionPattern.Text = "Instruction Patterns";
            // 
            // buttonMoveDownInstructionPattern
            // 
            buttonMoveDownInstructionPattern.Location = new Point(490, 132);
            buttonMoveDownInstructionPattern.Margin = new Padding(4, 3, 4, 3);
            buttonMoveDownInstructionPattern.Name = "buttonMoveDownInstructionPattern";
            buttonMoveDownInstructionPattern.Size = new Size(105, 27);
            buttonMoveDownInstructionPattern.TabIndex = 4;
            buttonMoveDownInstructionPattern.Text = "Move Down";
            buttonMoveDownInstructionPattern.UseVisualStyleBackColor = true;
            buttonMoveDownInstructionPattern.Click += buttonMoveDownInstructionPattern_Click;
            // 
            // buttonMoveUpInstructionPattern
            // 
            buttonMoveUpInstructionPattern.Location = new Point(490, 99);
            buttonMoveUpInstructionPattern.Margin = new Padding(4, 3, 4, 3);
            buttonMoveUpInstructionPattern.Name = "buttonMoveUpInstructionPattern";
            buttonMoveUpInstructionPattern.Size = new Size(105, 27);
            buttonMoveUpInstructionPattern.TabIndex = 3;
            buttonMoveUpInstructionPattern.Text = "Move Up";
            buttonMoveUpInstructionPattern.UseVisualStyleBackColor = true;
            buttonMoveUpInstructionPattern.Click += buttonMoveUpInstructionPattern_Click;
            // 
            // buttonRemoveInstructionPattern
            // 
            buttonRemoveInstructionPattern.Location = new Point(490, 55);
            buttonRemoveInstructionPattern.Margin = new Padding(4, 3, 4, 3);
            buttonRemoveInstructionPattern.Name = "buttonRemoveInstructionPattern";
            buttonRemoveInstructionPattern.Size = new Size(105, 27);
            buttonRemoveInstructionPattern.TabIndex = 2;
            buttonRemoveInstructionPattern.Text = "Remove Pattern";
            buttonRemoveInstructionPattern.UseVisualStyleBackColor = true;
            buttonRemoveInstructionPattern.Click += buttonRemoveInstructionPattern_Click;
            // 
            // listBoxInstructionPatterns
            // 
            listBoxInstructionPatterns.FormattingEnabled = true;
            listBoxInstructionPatterns.ItemHeight = 15;
            listBoxInstructionPatterns.Location = new Point(7, 22);
            listBoxInstructionPatterns.Margin = new Padding(4, 3, 4, 3);
            listBoxInstructionPatterns.Name = "listBoxInstructionPatterns";
            listBoxInstructionPatterns.Size = new Size(466, 139);
            listBoxInstructionPatterns.TabIndex = 0;
            // 
            // buttonAddInstructionPattern
            // 
            buttonAddInstructionPattern.Location = new Point(490, 22);
            buttonAddInstructionPattern.Margin = new Padding(4, 3, 4, 3);
            buttonAddInstructionPattern.Name = "buttonAddInstructionPattern";
            buttonAddInstructionPattern.Size = new Size(105, 27);
            buttonAddInstructionPattern.TabIndex = 1;
            buttonAddInstructionPattern.Text = "Add Pattern";
            buttonAddInstructionPattern.UseVisualStyleBackColor = true;
            buttonAddInstructionPattern.Click += buttonAddInstructionPattern_Click;
            // 
            // treeViewResults
            // 
            treeViewResults.Location = new Point(14, 290);
            treeViewResults.Margin = new Padding(4, 3, 4, 3);
            treeViewResults.Name = "treeViewResults";
            treeViewResults.Size = new Size(610, 230);
            treeViewResults.TabIndex = 6;
            // 
            // labelStatus
            // 
            labelStatus.AutoSize = true;
            labelStatus.Location = new Point(14, 530);
            labelStatus.Name = "labelStatus";
            labelStatus.Size = new Size(0, 15);
            labelStatus.TabIndex = 7;
            // 
            // buttonSaveResultToFile
            // 
            buttonSaveResultToFile.Location = new Point(429, 58);
            buttonSaveResultToFile.Margin = new Padding(4, 3, 4, 3);
            buttonSaveResultToFile.Name = "buttonSaveResultToFile";
            buttonSaveResultToFile.Size = new Size(175, 27);
            buttonSaveResultToFile.TabIndex = 8;
            buttonSaveResultToFile.Text = "Save Results to File";
            buttonSaveResultToFile.UseVisualStyleBackColor = true;
            buttonSaveResultToFile.Click += buttonSaveResultToFile_Click;
            // 
            // Form
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(642, 554);
            Controls.Add(buttonSaveResultToFile);
            Controls.Add(labelStatus);
            Controls.Add(treeViewResults);
            Controls.Add(groupBoxInstructionPattern);
            Controls.Add(buttonScanExecutables);
            Controls.Add(buttonLoadExecutables);
            Controls.Add(buttonBrowse);
            Controls.Add(textBoxPath);
            Controls.Add(labelPath);
            Margin = new Padding(4, 3, 4, 3);
            Name = "Form";
            ShowIcon = false;
            Text = "ROP Gadget Finder";
            FormClosing += Form_FormClosing;
            Load += Form_Load;
            groupBoxInstructionPattern.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label labelPath;
        private System.Windows.Forms.TextBox textBoxPath;
        private System.Windows.Forms.Button buttonBrowse;
        private System.Windows.Forms.Button buttonLoadExecutables;
        private System.Windows.Forms.Button buttonScanExecutables;
        private System.Windows.Forms.GroupBox groupBoxInstructionPattern;
        private System.Windows.Forms.ListBox listBoxInstructionPatterns;
        private System.Windows.Forms.Button buttonAddInstructionPattern;
        private System.Windows.Forms.TreeView treeViewResults;
        private Label labelStatus;
        private Button buttonSaveResultToFile;
        private Button buttonRemoveInstructionPattern;
        private Button buttonMoveDownInstructionPattern;
        private Button buttonMoveUpInstructionPattern;
    }
}
