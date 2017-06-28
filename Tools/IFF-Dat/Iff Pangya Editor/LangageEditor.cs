using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Iff_Pangya_Editor.IffFile;

namespace Iff_Pangya_Editor
{

    public partial class LangageEditor : Form
    {
        public class LangStock
        {
            public int Index;
            public string Langue;
        }

        public IFF_REGION RegionSelected = IffFile.IFF_REGION.Default;
        private List<LangStock> languelist;
        public LangageEditor()
        {
            InitializeComponent();
        }
 
        private void btnOpen_Click(object sender, EventArgs e)
        {
 
        }

        private void UpdateStringList()
        {
            if (txtFilter.Text == "")
            {
                this.lstStrings.Items.Clear();
                foreach (LangStock str in this.languelist)
                {
                    ListViewItem item = new ListViewItem(str.Langue)
                    {
                        Tag = str.Index
                    };
                    this.lstStrings.Items.Add(item);
                }
            }
            else
            {
                this.lstStrings.Items.Clear();
                foreach (LangStock str in this.languelist)
                {
                    ListViewItem item = new ListViewItem(str.Langue)
                    {
                        Tag = str.Index
                    };
                    bool found = str.Langue.Contains(txtFilter.Text);

                    if (found == true)
                        this.lstStrings.Items.Add(item);
                }
            }
        }

        private void lstStrings_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.lstStrings.SelectedItems.Count > 0)
            {
               LangStock SelectLang = this.languelist[(int)this.lstStrings.SelectedItems[0].Tag];
                this.txtString.Text = SelectLang.Langue.Replace("\n", "\r\n");
            }
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            if (txtString.Text != null)
            {

                languelist[(int)this.lstStrings.SelectedItems[0].Tag].Langue = this.txtString.Text.Replace("\r\n", "\n");
                UpdateStringList();
            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        { 
                //reset list
                UpdateStringList();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog
            {
                Title = "Open Language Files",
                Filter = "Pangya Languages (english.dat, thailand.dat)|*.dat"
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                this.languelist = new List<LangStock>();

                using (BinaryReader reader = new BinaryReader(File.Open(dialog.FileName, FileMode.Open, FileAccess.Read), IffFile.GetFileEncodingByRegion(RegionSelected)))
                {
                    int num = 0;
                    StringBuilder builder = new StringBuilder();
                    while (reader.BaseStream.Position < reader.BaseStream.Length)
                    {
                        if (reader.PeekChar() != 0)
                        {
                                builder.Append(reader.ReadChar());     
                        }
                        else
                        {
                            LangStock item = new LangStock
                            { 
                                Langue = builder.ToString(),
                                Index = num
                            };
                            this.languelist.Add(item);
                            builder = new StringBuilder();
                            reader.BaseStream.Seek(1L, SeekOrigin.Current);
                            num++;
                        }
                    }
                    UpdateStringList();
                }
            }
        }

        private void saveFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog
            {
                Title = "Save Language Files",
                Filter = "Pangya Languages (english.dat, thailand.dat)|*.dat"
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {

                using (BinaryWriter writer = new BinaryWriter(File.Open(dialog.FileName, FileMode.Create, FileAccess.Write), IffFile.GetFileEncodingByRegion(RegionSelected)))
                {
                    foreach (LangStock str in this.languelist)
                    {
                        char[] chars = str.Langue.ToCharArray();
                        writer.Write(chars);
                        writer.Write('\0');
                    }
                }
                MessageBox.Show("The language edited have been saved", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }
        private void Uncheck_all_encoding(object sender, EventArgs e)
        {
            eNGLISHToolStripMenuItem.Checked = false;
            jAPANToolStripMenuItem.Checked = false;
            tHAIToolStripMenuItem.Checked = false;
            oTHERToolStripMenuItem.Checked = false;
            autoToolStripMenuItem.Checked = false;
            kOREANToolStripMenuItem.Checked = false;
        }

        private void autoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Uncheck_all_encoding(sender, e);
            RegionSelected = IffFile.IFF_REGION.Default;
            autoToolStripMenuItem.Checked = true;
        }

        private void eNGLISHToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Uncheck_all_encoding(sender, e);
            RegionSelected = IffFile.IFF_REGION.Usa;
            eNGLISHToolStripMenuItem.Checked = true;
        }

        private void jAPANToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Uncheck_all_encoding(sender, e);
            RegionSelected = IffFile.IFF_REGION.Japan;
            jAPANToolStripMenuItem.Checked = true;
        }

        private void tHAIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Uncheck_all_encoding(sender, e);
            RegionSelected = IffFile.IFF_REGION.Thaiwan;
            tHAIToolStripMenuItem.Checked = true;
        }

        private void oTHERToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Uncheck_all_encoding(sender, e);
            RegionSelected = IffFile.IFF_REGION.Default;
            oTHERToolStripMenuItem.Checked = true;
        }

        private void kOREANToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Uncheck_all_encoding(sender, e);
            RegionSelected = IffFile.IFF_REGION.Korea;
            kOREANToolStripMenuItem.Checked = true;
        }
    }
}
