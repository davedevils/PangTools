using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ICSharpCode.SharpZipLib.Core;
using ICSharpCode.SharpZipLib.Zip;
using System.Drawing.Imaging;

namespace UCC_converter_Tools
{
    public partial class Form1 : Form
    {
        string ActualFileSD;
        Bitmap FrontImg;
        Bitmap BackImg;
        Bitmap IconImg;
        bool isRChar = false;
        bool AutoTransparancy = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "SelfDesign File (*.jpg)|*.jpg|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    ActualFileSD = System.IO.Path.GetFileNameWithoutExtension(openFileDialog1.FileName);
                    ExtractZipFile(openFileDialog1.FileName, "" , "C:\\Windows\\Temp\\davedevils\\" + ActualFileSD);
                    ReadPangyaPicture("front");
                    ReadPangyaPicture("back");
                    //ReadPangyaPicture("icon");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }

        public void ReadPangyaPicture(string filename)
        {

            int width = 128, height = 128;
            Bitmap flag = new Bitmap(width, height);
            int num2 = 0;
            long fileLength;
            ushort x = 0, y = 0;
            int[] hexacolor;
            int[] transcolor = new int[4];
            Color ColorPix = new Color();

            string path = "C:\\Windows\\Temp\\davedevils\\" + ActualFileSD + "\\" + filename;

            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.None);

            // SD Standard = 49152/65536 BYTE
            // SD 256x256  = 196608 BYTE
            //string size = fs.Length.ToString();
            //MessageBox.Show(size);

            fileLength = fs.Length;
            fs.Close();

            if (fileLength > 65536 )
            {
                width = 256;
                height = 256;
                flag = new Bitmap(width, height);
            }
            //short 
            //128x64
            if (fileLength < 30000)
            {
                width = 128;
                height = 64;
                flag = new Bitmap(width, height);
            }
            

            byte[] fileBytes = File.ReadAllBytes(path);
            while (num2 < fileBytes.Length)
            {
                int numwhile = 3;

                if (isRChar == false)
                    numwhile = 4;

                hexacolor = new int[4];

                for (int W = 0; W < numwhile; W++)
                {
                    hexacolor[W] = fileBytes[num2];

                    if (hexacolor[W] < 0)
                        hexacolor[W] = 0;  

                    if(hexacolor[W] > 255)
                        hexacolor[W] = 255;

                    num2 += 1;
                }

                
                if (isRChar == false)
                {
                    ColorPix = Color.FromArgb(hexacolor[3], hexacolor[2], hexacolor[1], hexacolor[0]);
                }
                else
                {
                    if (AutoTransparancy == true && num2 < 4)
                    {
                        ColorPix = Color.FromArgb(0, hexacolor[2], hexacolor[1], hexacolor[0]);
                        transcolor = hexacolor;
                    }
                    else if (AutoTransparancy == true)
                    {
                        if (transcolor == hexacolor)
                            ColorPix = Color.FromArgb(0, hexacolor[2], hexacolor[1], hexacolor[0]);
                        else
                            ColorPix = Color.FromArgb(255, hexacolor[2], hexacolor[1], hexacolor[0]);
                    }
                    else
                    {
                        ColorPix = Color.FromArgb(255, hexacolor[2], hexacolor[1], hexacolor[0]);
                    }
                }

                flag.SetPixel(x, y, ColorPix);

                x++;
                if (x == width)
                {
                    y++;
                    x = 0;
                }
            }

            Graphics flagGraphics = Graphics.FromImage(flag);

            if (filename == "front")
            {
                picfront.Image = flag;
                FrontImg = flag;
            }
            else if (filename == "back")
            {
                picback.Image = flag;
                BackImg = flag;
            }
            else if (filename == "icon")
            {
                //picicon.Image = flag;
                IconImg = flag;
            }
        }

        public void SavePangyaPicture(string filename , Bitmap Img)
        {

            int width = Img.Width;
            int height = Img.Height;

            int x = 0;
            int y = 0;
            FileStream fs = new FileStream("C:\\Windows\\Temp\\davedevils\\" + ActualFileSD + "\\" + filename, FileMode.Create, FileAccess.Write);
            while (y < height)
            {
                Color pix = Img.GetPixel(x, y);
                fs.WriteByte(pix.B);
                fs.WriteByte(pix.G);
                fs.WriteByte(pix.R);

                if (isRChar == false)
                    fs.WriteByte(pix.A);

                x++;
                if (x == width)
                {
                    x = 0;
                    y++;
                }
            }

            fs.Close();
        }
        public void ExtractZipFile(string archiveFilenameIn, string password, string outFolder)
        {
            ZipFile zf = null;
            try
            {
                FileStream fs = File.OpenRead(archiveFilenameIn);
                zf = new ZipFile(fs);
                if (!String.IsNullOrEmpty(password))
                {
                    zf.Password = password;     // AES encrypted entries are handled automatically
                }
                foreach (ZipEntry zipEntry in zf)
                {
                    if (!zipEntry.IsFile)
                    {
                        continue;           // Ignore directories
                    }
                    String entryFileName = zipEntry.Name;
                    // to remove the folder from the entry:- entryFileName = Path.GetFileName(entryFileName);
                    // Optionally match entrynames against a selection list here to skip as desired.
                    // The unpacked length is available in the zipEntry.Size property.

                    byte[] buffer = new byte[4096];     // 4K is optimum
                    Stream zipStream = zf.GetInputStream(zipEntry);

                    // Manipulate the output filename here as desired.
                    String fullZipToPath = Path.Combine(outFolder, entryFileName);
                    string directoryName = Path.GetDirectoryName(fullZipToPath);
                    if (directoryName.Length > 0)
                        Directory.CreateDirectory(directoryName);

                    // Unzip file in buffered chunks. This is just as fast as unpacking to a buffer the full size
                    // of the file, but does not waste memory.
                    // The "using" will close the stream even if an exception occurs.
                    using (FileStream streamWriter = File.Create(fullZipToPath))
                    {
                        StreamUtils.Copy(zipStream, streamWriter, buffer);
                    }
                }
            }
            finally
            {
                if (zf != null)
                {
                    zf.IsStreamOwner = true; // Makes close also shut the underlying stream
                    zf.Close(); // Ensure we release resources
                }
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            SavePangyaPicture("front" , FrontImg);
            SavePangyaPicture("back" , BackImg);

            //isRChar = true;
            //SavePangyaPicture("icon", BackImg);

            ICSharpCode.SharpZipLib.Zip.FastZip z = new ICSharpCode.SharpZipLib.Zip.FastZip();
            z.CreateEmptyDirectories = false;
            z.CreateZip( ActualFileSD + ".jpg", "C:\\Windows\\Temp\\davedevils\\" + ActualFileSD, true, "");

            if (File.Exists(ActualFileSD + ".jpg"))
                MessageBox.Show("Saved at " + ActualFileSD + ".jpg");
            else
                MessageBox.Show("Save has fail :(");

        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //export
            bool exists = System.IO.Directory.Exists(ActualFileSD);

            if (!exists)
                System.IO.Directory.CreateDirectory(ActualFileSD);

            Bitmap frontsave = new Bitmap(FrontImg);
            Bitmap backsave = new Bitmap(BackImg);
            frontsave.Save(ActualFileSD + "\\" + "front.png", ImageFormat.Png);
            backsave.Save(ActualFileSD + "\\" + "back.png", ImageFormat.Png);


            frontsave.Dispose();
            backsave.Dispose();

            MessageBox.Show("Saved in folder :" + ActualFileSD);
        }

        private void importToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (File.Exists(ActualFileSD + "\\" + "front.png") == false 
                || File.Exists(ActualFileSD + "\\" + "back.png") == false)
            {
                MessageBox.Show("You need import before export ... The Folder of import ->  :" + ActualFileSD);
            }
            else
            {
                //import
                Image Front = Image.FromFile(ActualFileSD + "\\" + "front.png");
                Image Back = Image.FromFile(ActualFileSD + "\\" + "back.png");

                Bitmap frontload = new Bitmap(Front);
                Bitmap backload = new Bitmap(Back);

                picfront.Image = frontload;
                FrontImg = new Bitmap(picfront.Image);
                picback.Image = backload;
                BackImg = new Bitmap(picback.Image);

                Back.Dispose();
                Front.Dispose();
                MessageBox.Show("File have been imported");
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked == true)
                 isRChar = true;
            else
                isRChar = false;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
                AutoTransparancy = true;
            else
                AutoTransparancy = false;
        }
    }
}
