using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Iff_Pangya_Editor
{
    public partial class MainWindow : Form
    {
        private static CreditWindow openCredit;
        public MainWindow()
        {
            openCredit = null;
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new LangageEditor().Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            new Desc_Editor().Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (openCredit == null)
            {
                openCredit = new CreditWindow();
                openCredit.Show();
                openCredit.FormClosed += delegate { openCredit = null; };
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            new CharacterEditor().Show();
        }
    }
}
