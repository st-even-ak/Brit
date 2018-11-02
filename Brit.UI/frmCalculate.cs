using System;
using System.Globalization;
using System.Windows.Forms;
using Autofac;
using Brit.Service.Interfaces;

namespace Brit.UI
{
    public partial class FrmCalculator : Form
    {
        public FrmCalculator()
        {
            InitializeComponent();
        }

        private void BtnCalc_Click(object sender, EventArgs e)
        {
            RefreshDisplay();

            using (var scope = Program.Container.BeginLifetimeScope())
            {

                var service = scope.Resolve<ICalculator>();
                var result = service.Apply(txtInput.Text);

                if (result.HasException)
                {
                    rtbOutput.Text = result.Exception;
                }
                else
                {
                    foreach (var key in result.Results.Keys)
                    {
                        rtbOutput.AppendText($"{key} = {result.Results[key].ToString(CultureInfo.CurrentCulture)}\n");
                    }
                }
            }
        }

        private void BtnInputSelect_Click(object sender, EventArgs e)
        {
            var dialogResult = dlgInputFile.ShowDialog();

            if (dialogResult.Equals(DialogResult.OK))
            {
                txtInput.Text = dlgInputFile.FileName;
                btnShowNotes.Text = "Show Notes";
                rtbOutput.Clear();
            }
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            txtInput.Text = string.Empty;
            RefreshDisplay();
        }

        private void RefreshDisplay()
        {
            rtbOutput.Clear();
            btnShowNotes.Text = "Show Notes";
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BtnInputSelect_Click(sender, e);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnShowNotes_Click(object sender, EventArgs e)
        {
            if (btnShowNotes.Text == "Show Notes")
            {
                rtbOutput.Clear();
                rtbOutput.AppendText("1 Select a file contain a list of instructions\n");
                rtbOutput.AppendText("2 Calculation Tool Supports:\n");
                rtbOutput.AppendText("  2.1 Add\n");
                rtbOutput.AppendText("  2.2 Subtract\n");
                rtbOutput.AppendText("  2.3 Multiply\n");
                rtbOutput.AppendText("  2.4 Divide\n");
                rtbOutput.AppendText("  2.5 Power\n");
                rtbOutput.AppendText("  2.6 Root\n");
                btnShowNotes.Text = "Hide Notes";
            }
            else
            {
                rtbOutput.Clear();
                btnShowNotes.Text = "Show Notes";
            }
        }
    }
}
