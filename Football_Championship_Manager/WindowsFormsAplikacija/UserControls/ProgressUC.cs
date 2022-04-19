using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAplikacija.UserControls
{
    public partial class ProgressUC : UserControl
    {
        public int Postotak
        {
            get => progressBar.Value;
                
            set
            {
                if (value < progressBar.Minimum || value > progressBar.Maximum)
                {
                    return;
                }

                progressBar.Value = value;
                lblPostotak.Text = $"{value / 10}%";
            }
        }
        public ProgressUC()
        {
            InitializeComponent();
        }

        public void PovecajPostotak(int value)
        {
            Postotak += value;
        }
        public void RestetirajPostotak()
        {
            Controls.Clear();
            InitializeComponent();
        }
    }
}
