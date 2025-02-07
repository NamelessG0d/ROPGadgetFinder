namespace ROPGadgetFinder
{
    partial class AddPatternForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            labelInstructionId = new Label();
            comboBoxInstructionId = new ComboBox();
            checkBoxWrittenRegistersCount = new CheckBox();
            labelWrittenRegistersLength = new Label();
            numericUpDownWrittenRegistersLength = new NumericUpDown();
            checkBoxReadRegisters = new CheckBox();
            checkedListBoxReadRegisters = new CheckedListBox();
            buttonOK = new Button();
            buttonCancel = new Button();
            checkBoxWrittenRegisters = new CheckBox();
            checkedListBoxWrittenRegisters = new CheckedListBox();
            checkBoxReadRegistersCount = new CheckBox();
            labelReadRegistersLength = new Label();
            numericUpDownReadRegistersLength = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)numericUpDownWrittenRegistersLength).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownReadRegistersLength).BeginInit();
            SuspendLayout();
            // 
            // labelInstructionId
            // 
            labelInstructionId.AutoSize = true;
            labelInstructionId.Location = new Point(14, 17);
            labelInstructionId.Margin = new Padding(4, 0, 4, 0);
            labelInstructionId.Name = "labelInstructionId";
            labelInstructionId.Size = new Size(80, 15);
            labelInstructionId.TabIndex = 0;
            labelInstructionId.Text = "Instruction Id:";
            // 
            // comboBoxInstructionId
            // 
            comboBoxInstructionId.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxInstructionId.FormattingEnabled = true;
            comboBoxInstructionId.Location = new Point(117, 14);
            comboBoxInstructionId.Margin = new Padding(4, 3, 4, 3);
            comboBoxInstructionId.Name = "comboBoxInstructionId";
            comboBoxInstructionId.Size = new Size(233, 23);
            comboBoxInstructionId.TabIndex = 1;
            // 
            // checkBoxWrittenRegistersCount
            // 
            checkBoxWrittenRegistersCount.AutoSize = true;
            checkBoxWrittenRegistersCount.Location = new Point(14, 401);
            checkBoxWrittenRegistersCount.Margin = new Padding(4, 3, 4, 3);
            checkBoxWrittenRegistersCount.Name = "checkBoxWrittenRegistersCount";
            checkBoxWrittenRegistersCount.Size = new Size(192, 19);
            checkBoxWrittenRegistersCount.TabIndex = 2;
            checkBoxWrittenRegistersCount.Text = "Specify Written Registers Count";
            checkBoxWrittenRegistersCount.UseVisualStyleBackColor = true;
            checkBoxWrittenRegistersCount.CheckedChanged += checkBoxWrittenRegistersCount_CheckedChanged;
            // 
            // labelWrittenRegistersLength
            // 
            labelWrittenRegistersLength.AutoSize = true;
            labelWrittenRegistersLength.Location = new Point(28, 432);
            labelWrittenRegistersLength.Margin = new Padding(4, 0, 4, 0);
            labelWrittenRegistersLength.Name = "labelWrittenRegistersLength";
            labelWrittenRegistersLength.Size = new Size(139, 15);
            labelWrittenRegistersLength.TabIndex = 3;
            labelWrittenRegistersLength.Text = "Written Registers Length:";
            // 
            // numericUpDownWrittenRegistersLength
            // 
            numericUpDownWrittenRegistersLength.Enabled = false;
            numericUpDownWrittenRegistersLength.Location = new Point(171, 430);
            numericUpDownWrittenRegistersLength.Margin = new Padding(4, 3, 4, 3);
            numericUpDownWrittenRegistersLength.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDownWrittenRegistersLength.Name = "numericUpDownWrittenRegistersLength";
            numericUpDownWrittenRegistersLength.Size = new Size(70, 23);
            numericUpDownWrittenRegistersLength.TabIndex = 4;
            numericUpDownWrittenRegistersLength.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // checkBoxReadRegisters
            // 
            checkBoxReadRegisters.AutoSize = true;
            checkBoxReadRegisters.Location = new Point(18, 47);
            checkBoxReadRegisters.Margin = new Padding(4, 3, 4, 3);
            checkBoxReadRegisters.Name = "checkBoxReadRegisters";
            checkBoxReadRegisters.Size = new Size(164, 19);
            checkBoxReadRegisters.TabIndex = 5;
            checkBoxReadRegisters.Text = "Specify Read Registers List";
            checkBoxReadRegisters.UseVisualStyleBackColor = true;
            checkBoxReadRegisters.CheckedChanged += checkBoxReadRegisters_CheckedChanged;
            // 
            // checkedListBoxReadRegisters
            // 
            checkedListBoxReadRegisters.Enabled = false;
            checkedListBoxReadRegisters.FormattingEnabled = true;
            checkedListBoxReadRegisters.Location = new Point(18, 72);
            checkedListBoxReadRegisters.Margin = new Padding(4, 3, 4, 3);
            checkedListBoxReadRegisters.Name = "checkedListBoxReadRegisters";
            checkedListBoxReadRegisters.Size = new Size(332, 94);
            checkedListBoxReadRegisters.TabIndex = 6;
            // 
            // buttonOK
            // 
            buttonOK.Location = new Point(168, 478);
            buttonOK.Margin = new Padding(4, 3, 4, 3);
            buttonOK.Name = "buttonOK";
            buttonOK.Size = new Size(88, 27);
            buttonOK.TabIndex = 7;
            buttonOK.Text = "OK";
            buttonOK.UseVisualStyleBackColor = true;
            buttonOK.Click += buttonOK_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(262, 478);
            buttonCancel.Margin = new Padding(4, 3, 4, 3);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(88, 27);
            buttonCancel.TabIndex = 8;
            buttonCancel.Text = "Cancel";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // checkBoxWrittenRegisters
            // 
            checkBoxWrittenRegisters.AutoSize = true;
            checkBoxWrittenRegisters.Location = new Point(14, 266);
            checkBoxWrittenRegisters.Margin = new Padding(4, 3, 4, 3);
            checkBoxWrittenRegisters.Name = "checkBoxWrittenRegisters";
            checkBoxWrittenRegisters.Size = new Size(177, 19);
            checkBoxWrittenRegisters.TabIndex = 5;
            checkBoxWrittenRegisters.Text = "Specify Written Registers List";
            checkBoxWrittenRegisters.UseVisualStyleBackColor = true;
            checkBoxWrittenRegisters.CheckedChanged += checkBoxWrittenRegisters_CheckedChanged;
            // 
            // checkedListBoxWrittenRegisters
            // 
            checkedListBoxWrittenRegisters.Enabled = false;
            checkedListBoxWrittenRegisters.FormattingEnabled = true;
            checkedListBoxWrittenRegisters.Location = new Point(14, 291);
            checkedListBoxWrittenRegisters.Margin = new Padding(4, 3, 4, 3);
            checkedListBoxWrittenRegisters.Name = "checkedListBoxWrittenRegisters";
            checkedListBoxWrittenRegisters.Size = new Size(332, 94);
            checkedListBoxWrittenRegisters.TabIndex = 6;
            // 
            // checkBoxReadRegistersCount
            // 
            checkBoxReadRegistersCount.AutoSize = true;
            checkBoxReadRegistersCount.Location = new Point(18, 184);
            checkBoxReadRegistersCount.Margin = new Padding(4, 3, 4, 3);
            checkBoxReadRegistersCount.Name = "checkBoxReadRegistersCount";
            checkBoxReadRegistersCount.Size = new Size(179, 19);
            checkBoxReadRegistersCount.TabIndex = 2;
            checkBoxReadRegistersCount.Text = "Specify Read Registers Count";
            checkBoxReadRegistersCount.UseVisualStyleBackColor = true;
            checkBoxReadRegistersCount.CheckedChanged += checkBoxReadRegistersCount_CheckedChanged;
            // 
            // labelReadRegistersLength
            // 
            labelReadRegistersLength.AutoSize = true;
            labelReadRegistersLength.Location = new Point(32, 215);
            labelReadRegistersLength.Margin = new Padding(4, 0, 4, 0);
            labelReadRegistersLength.Name = "labelReadRegistersLength";
            labelReadRegistersLength.Size = new Size(126, 15);
            labelReadRegistersLength.TabIndex = 3;
            labelReadRegistersLength.Text = "Read Registers Length:";
            // 
            // numericUpDownReadRegistersLength
            // 
            numericUpDownReadRegistersLength.Enabled = false;
            numericUpDownReadRegistersLength.Location = new Point(175, 213);
            numericUpDownReadRegistersLength.Margin = new Padding(4, 3, 4, 3);
            numericUpDownReadRegistersLength.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDownReadRegistersLength.Name = "numericUpDownReadRegistersLength";
            numericUpDownReadRegistersLength.Size = new Size(70, 23);
            numericUpDownReadRegistersLength.TabIndex = 4;
            numericUpDownReadRegistersLength.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // AddPatternForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(373, 521);
            Controls.Add(buttonCancel);
            Controls.Add(buttonOK);
            Controls.Add(checkedListBoxWrittenRegisters);
            Controls.Add(checkBoxWrittenRegisters);
            Controls.Add(checkedListBoxReadRegisters);
            Controls.Add(checkBoxReadRegisters);
            Controls.Add(numericUpDownReadRegistersLength);
            Controls.Add(numericUpDownWrittenRegistersLength);
            Controls.Add(labelReadRegistersLength);
            Controls.Add(labelWrittenRegistersLength);
            Controls.Add(checkBoxReadRegistersCount);
            Controls.Add(checkBoxWrittenRegistersCount);
            Controls.Add(comboBoxInstructionId);
            Controls.Add(labelInstructionId);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AddPatternForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Add Instruction Pattern";
            ShowIcon = false;
            ((System.ComponentModel.ISupportInitialize)numericUpDownWrittenRegistersLength).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownReadRegistersLength).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label labelInstructionId;
        private System.Windows.Forms.ComboBox comboBoxInstructionId;
        private System.Windows.Forms.CheckBox checkBoxWrittenRegistersCount;
        private System.Windows.Forms.Label labelWrittenRegistersLength;
        private System.Windows.Forms.NumericUpDown numericUpDownWrittenRegistersLength;
        private System.Windows.Forms.CheckBox checkBoxReadRegisters;
        private System.Windows.Forms.CheckedListBox checkedListBoxReadRegisters;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private CheckBox checkBoxWrittenRegisters;
        private CheckedListBox checkedListBoxWrittenRegisters;
        private CheckBox checkBoxReadRegistersCount;
        private Label labelReadRegistersLength;
        private NumericUpDown numericUpDownReadRegistersLength;
    }
}