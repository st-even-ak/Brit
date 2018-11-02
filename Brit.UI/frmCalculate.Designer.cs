namespace Brit.UI
{
    partial class FrmCalculator
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
            this.txtInput = new System.Windows.Forms.TextBox();
            this.btnInputSelect = new System.Windows.Forms.Button();
            this.pnlListContainer = new System.Windows.Forms.Panel();
            this.rtbOutput = new System.Windows.Forms.RichTextBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnCalc = new System.Windows.Forms.Button();
            this.dlgInputFile = new System.Windows.Forms.OpenFileDialog();
            this.btnShowNotes = new System.Windows.Forms.Button();
            this.pnlListContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtInput
            // 
            this.txtInput.Location = new System.Drawing.Point(12, 48);
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(632, 38);
            this.txtInput.TabIndex = 0;
            // 
            // btnInputSelect
            // 
            this.btnInputSelect.Location = new System.Drawing.Point(674, 42);
            this.btnInputSelect.Name = "btnInputSelect";
            this.btnInputSelect.Size = new System.Drawing.Size(200, 48);
            this.btnInputSelect.TabIndex = 1;
            this.btnInputSelect.Text = "Select File";
            this.btnInputSelect.UseVisualStyleBackColor = true;
            this.btnInputSelect.Click += new System.EventHandler(this.BtnInputSelect_Click);
            // 
            // pnlListContainer
            // 
            this.pnlListContainer.Controls.Add(this.rtbOutput);
            this.pnlListContainer.Location = new System.Drawing.Point(12, 135);
            this.pnlListContainer.Name = "pnlListContainer";
            this.pnlListContainer.Size = new System.Drawing.Size(862, 605);
            this.pnlListContainer.TabIndex = 3;
            // 
            // rtbOutput
            // 
            this.rtbOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbOutput.Location = new System.Drawing.Point(0, 0);
            this.rtbOutput.Name = "rtbOutput";
            this.rtbOutput.Size = new System.Drawing.Size(862, 605);
            this.rtbOutput.TabIndex = 0;
            this.rtbOutput.Text = "";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(674, 762);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(200, 48);
            this.btnClear.TabIndex = 4;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.BtnClear_Click);
            // 
            // btnCalc
            // 
            this.btnCalc.Location = new System.Drawing.Point(444, 762);
            this.btnCalc.Name = "btnCalc";
            this.btnCalc.Size = new System.Drawing.Size(200, 48);
            this.btnCalc.TabIndex = 5;
            this.btnCalc.Text = "Calculate";
            this.btnCalc.UseVisualStyleBackColor = true;
            this.btnCalc.Click += new System.EventHandler(this.BtnCalc_Click);
            // 
            // dlgInputFile
            // 
            this.dlgInputFile.Filter = "Files|*.txt";
            // 
            // btnShowNotes
            // 
            this.btnShowNotes.Location = new System.Drawing.Point(12, 762);
            this.btnShowNotes.Name = "btnShowNotes";
            this.btnShowNotes.Size = new System.Drawing.Size(200, 48);
            this.btnShowNotes.TabIndex = 6;
            this.btnShowNotes.Text = "Show Notes";
            this.btnShowNotes.UseVisualStyleBackColor = true;
            this.btnShowNotes.Click += new System.EventHandler(this.btnShowNotes_Click);
            // 
            // FrmCalculator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(886, 822);
            this.Controls.Add(this.btnShowNotes);
            this.Controls.Add(this.btnCalc);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.pnlListContainer);
            this.Controls.Add(this.btnInputSelect);
            this.Controls.Add(this.txtInput);
            this.Name = "FrmCalculator";
            this.Text = "Calculate";
            this.pnlListContainer.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.Button btnInputSelect;
        private System.Windows.Forms.Panel pnlListContainer;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnCalc;
        private System.Windows.Forms.OpenFileDialog dlgInputFile;
        private System.Windows.Forms.RichTextBox rtbOutput;
        private System.Windows.Forms.Button btnShowNotes;
    }
}

