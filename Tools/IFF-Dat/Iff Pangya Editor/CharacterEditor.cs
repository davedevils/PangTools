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
    public partial class CharacterEditor : Form
    {
        public class CharacterStock // based on file struct
        {
            public int      Index;
            public uint      Active;
            public uint      TypeId;
            public string   Name;
            public byte    Level;
            public string   Icon;
            public byte    Flag1;
            public byte    Flag2;
            public byte    Flag3;
            public uint      Price;
            public uint      DiscountPrice;
            public uint      UsedPrice;
            public uint      FlagShop;
            public uint      Qnt_Tiki_Pts;
            public uint      Tiki_Pts;
            public ushort    Recyling_Pts;  //Mileage Points
            public ushort    Bonus_Proba;
            public ushort    Recyling_Pts2;
            public ushort    Recyling_Pts3;
            public uint      Type_Tiki;
            public uint      Tiki_Pang;
            public uint      Active_Date;
            public string   Activate_Date; // size 16
            public string   End_Date;  // size 16
            public string   Model;  // size 40
            public string   Tex_01; // size 40
            public string   Tex_02; // size 40
            public string   Tex_03; // size 40
            public ushort    Power;
            public ushort    Control;
            public ushort    Accuracy;
            public ushort    Spin;
            public ushort    Curve;
            public byte    PowerSlot;
            public byte    ControlSlot;
            public byte    AccuracySlot;
            public byte    SpinSlot;
            public byte    CurveSlot;
            public byte    Unknow_1;
            public uint      RankS;
            public byte    RankS_PowerSlot;
            public byte    RankS_ControlSlot;
            public byte    RankS_AccuracySlot;
            public byte    RankS_SpinSlot;
            public byte    RankS_CurveSlot;
            public string   Additional_Tex; // size 40
            public string     Unknow_3; // size 3            
        }

        List<CharacterStock> CharacterListing;
        public IFF_REGION RegionSelected = IffFile.IFF_REGION.Default;
        public CharacterEditor()
        {
            InitializeComponent();
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

        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog
            {
                Filter = "Pangya IFF Character (Character*.iff)|Character*.iff",
                Title = "Open IFF Desc"
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                CharacterListing = new List<CharacterStock>();
                using (BinaryReader reader = new BinaryReader(File.Open(dialog.FileName, FileMode.Open, FileAccess.Read), IffFile.GetFileEncodingByRegion(RegionSelected)))
                {
                    IffFile file = new IffFile();
                    ushort numberOfRecords = file.GetNumberOfRecords(reader);
                    file.JumpToFirstRecord(reader);
                    if (file.CheckMagicNumber(reader))
                    {
                        for (int i = 0; i < numberOfRecords; i++)
                        {
                            //GetFileEncodingByRegion(RegionSelected).GetString(reader.ReadBytes(XXXXXXXX)); --> exemple for encoding string
                            long position = reader.BaseStream.Position;

                            // added the virtual number 
                            CharacterStock item = new CharacterStock
                            {
                                Index = i
                            };

                            //Now laborious work -> Read The file 
                            item.Active             = reader.ReadUInt32();
                            item.TypeId             = reader.ReadUInt32();
                            item.Name               = GetFileEncodingByRegion(RegionSelected).GetString(reader.ReadBytes(40)); // 40 Byte long
                            item.Level              = reader.ReadByte();
                            item.Icon               = GetFileEncodingByRegion(RegionSelected).GetString(reader.ReadBytes(40)); // 40 Byte long
                            //Do a trick for flag for have clean read
                            item.Flag1            = reader.ReadByte();
                            item.Flag2            = reader.ReadByte();
                            item.Flag3            = reader.ReadByte();
                            item.Price              = reader.ReadUInt32();
                            item.DiscountPrice      = reader.ReadUInt32();
                            item.UsedPrice          = reader.ReadUInt32();
                            item.FlagShop           = reader.ReadUInt32();
                            item.Qnt_Tiki_Pts       = reader.ReadUInt32();
                            item.Tiki_Pts           = reader.ReadUInt32();
                            item.Recyling_Pts       = reader.ReadUInt16();
                            item.Bonus_Proba        = reader.ReadUInt16();
                            item.Recyling_Pts2      = reader.ReadUInt16();
                            item.Recyling_Pts3      = reader.ReadUInt16();
                            item.Type_Tiki          = reader.ReadUInt32();
                            item.Tiki_Pang          = reader.ReadUInt32();
                            item.Active_Date        = reader.ReadUInt32();
                            item.Activate_Date      = GetFileEncodingByRegion(RegionSelected).GetString(reader.ReadBytes(16)); // 16 Byte long
                            item.End_Date           = GetFileEncodingByRegion(RegionSelected).GetString(reader.ReadBytes(16)); // 16 Byte long
                            item.Model              = GetFileEncodingByRegion(RegionSelected).GetString(reader.ReadBytes(40)); // 40 Byte long
                            item.Tex_01             = GetFileEncodingByRegion(RegionSelected).GetString(reader.ReadBytes(40)); // 40 Byte long
                            item.Tex_02             = GetFileEncodingByRegion(RegionSelected).GetString(reader.ReadBytes(40)); // 40 Byte long
                            item.Tex_03             = GetFileEncodingByRegion(RegionSelected).GetString(reader.ReadBytes(40)); // 40 Byte long
                            item.Power              = reader.ReadUInt16();
                            item.Control            = reader.ReadUInt16();
                            item.Accuracy           = reader.ReadUInt16();
                            item.Spin               = reader.ReadUInt16();
                            item.Curve              = reader.ReadUInt16();
                            item.PowerSlot          = reader.ReadByte();
                            item.ControlSlot        = reader.ReadByte();
                            item.AccuracySlot       = reader.ReadByte();
                            item.SpinSlot           = reader.ReadByte();
                            item.CurveSlot          = reader.ReadByte();
                            item.Unknow_1           = reader.ReadByte();
                            item.RankS              = reader.ReadUInt32();
                            item.RankS_PowerSlot    = reader.ReadByte();
                            item.RankS_ControlSlot  = reader.ReadByte();
                            item.RankS_AccuracySlot = reader.ReadByte();
                            item.RankS_SpinSlot     = reader.ReadByte();
                            item.RankS_CurveSlot    = reader.ReadByte();
                            item.Additional_Tex     = GetFileEncodingByRegion(RegionSelected).GetString(reader.ReadBytes(40)); // 40 Byte long
                            item.Unknow_3           = GetFileEncodingByRegion(RegionSelected).GetString(reader.ReadBytes(3)); // 3 Byte long

                            //Adding to the list
                            CharacterListing.Add(item); 
                        }
                       reader.Close();
                    }
                    UpdateStringList();
                }
            }
        }

        private void saveFileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void lstStrings_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.lstStrings.SelectedItems.Count > 0)
            {
                CharacterStock SelectChar = this.CharacterListing[(int)lstStrings.SelectedItems[0].Tag];
                CharacterName.Text  = SelectChar.Name;
                Model.Text          = SelectChar.Model;
                tex1.Text           = SelectChar.Tex_01;
                tex2.Text           = SelectChar.Tex_02;
                tex3.Text           = SelectChar.Tex_03;
                tex4.Text           = SelectChar.Additional_Tex;
            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            UpdateStringList();
        }

        private void UpdateStringList()
        {
            if (CharacterListing != null)
            {
                if (txtFilter.Text == "")
                {
                    this.lstStrings.Items.Clear();
                    foreach (CharacterStock str in this.CharacterListing)
                    {
                        ListViewItem item = new ListViewItem(str.Name)
                        {
                            Tag = str.Index
                        };
                        this.lstStrings.Items.Add(item);
                    }
                }
                else
                {
                    this.lstStrings.Items.Clear();
                    foreach (CharacterStock str in this.CharacterListing)
                    {
                        ListViewItem item = new ListViewItem(str.Name)
                        {
                            Tag = str.Index

                        };
                        bool found = str.Name.Contains(txtFilter.Text);

                        if (found == true)
                            this.lstStrings.Items.Add(item);
                    }
                }
            }
        }
    }
}
