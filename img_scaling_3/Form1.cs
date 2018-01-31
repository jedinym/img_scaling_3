using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.IO;

namespace img_scaling_3
{
    public partial class frm_main : Form
    {
        int MaxDim = 11000;
        Picture OriginalFile;
        byte[] StoredBytes;
        string Filter = "Image Files(*.BMP; *.JPEG; *.JPG; *.PNG)|*.BMP; *.JPEG; *.JPG; *.PNG|All Files(*.*)|*.*";

        public frm_main()
        {
            InitializeComponent();
        }

        private void btn_load_Click(object sender, EventArgs e)
        {
            lbl_saved.Visible = false;
            ofd_original.Filter = Filter;

            if (ofd_original.ShowDialog() == DialogResult.OK)
            {
                string originalFilePath = ofd_original.FileName;
                StoredBytes = ByteImage.GetBytesFromFilepath(originalFilePath);
                if (StoredBytes != null)
                {
                    OriginalFile = new Picture(ByteImage.GetImageFromBytes(StoredBytes));
                    Bitmap pictureBoxFile = ScaleDownForPictureBox();
                    pbx_original.Image = pictureBoxFile;
                    btn_resize_Click(null, null);
                    //pbx_edited.Image = pictureBoxFile;
                }
                else
                {
                    MessageBox.Show("File not convertible to bitmap!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }
        private void btn_resize_Click(object sender, EventArgs e)
        {
            if (OriginalFile.Bitmap != null && (nmr_width.Value > 0 || nmr_height.Value > 0))
            {
                pbx_edited.Image = ScaleDownImage(OriginalFile.Bitmap, GetDimension(), GetUsage());
            }
        }
        private void btn_save_Click(object sender, EventArgs e)
        {
            int dimension = GetDimension();
            Bitmap editedImage = ScaleDownImage(OriginalFile.Bitmap, dimension, GetUsage());
            if (dimension != -1)
            {
                Save(editedImage);
            }
        }
        private Bitmap ScaleDownForPictureBox()
        {
            double bitmapWidth = OriginalFile.Bitmap.Width;
            double bitmapHeight = OriginalFile.Bitmap.Height;

            double pictureBoxWidth = pbx_original.Width;
            double pictureBoxHeight = pbx_original.Height;

            double ratio = (OriginalFile.isWide) ? pictureBoxWidth / bitmapWidth : pictureBoxHeight / bitmapHeight;

            bitmapHeight *= ratio;
            bitmapWidth *= ratio;

            Math.Round(bitmapHeight, 1);
            Math.Round(bitmapWidth, 1);

            Size size = new Size((int)bitmapWidth, (int)bitmapHeight);
            return new Bitmap(OriginalFile.Bitmap, size);
        }
        private Bitmap ScaleDownImage(Bitmap _bitmap, int _dimension, int _useWidth)
        {
            if (_useWidth != 3 && _dimension != -1 && _dimension != 0)
            {
                double bitmapWidth = _bitmap.Width;
                double bitmapHeight = _bitmap.Height;

                Size size;

                if (nmr_width.Value > MaxDim || nmr_height.Value > MaxDim)
                {
                    MessageBox.Show("Max dimension exceeded;" + Environment.NewLine + "Setting maximum possible dimension...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    size = GetMaxSize(OriginalFile.ratio);

                }
                else
                {
                    double newWidth;
                    double newHeight;
                    if (_useWidth == 1)
                    {
                        newWidth = (double)nmr_width.Value;
                        newHeight = ((newWidth * OriginalFile.ratio) < 1) ? 1 : newWidth * OriginalFile.ratio;

                    }
                    else
                    {
                        newHeight = (double)nmr_height.Value;
                        newWidth = ((newHeight * OriginalFile.ratio) < 1) ? 1 : newHeight * OriginalFile.ratio; 
                    }

                //bitmapHeight *= OriginalFile.ratio;
                //bitmapWidth *= OriginalFile.ratio;

                size = new Size((int)newWidth, (int)newHeight);
                }

                //new Size((int)bitmapWidth, (int)bitmapHeight);
                return new Bitmap(_bitmap, size);

            }
            return (Bitmap)pbx_original.Image;        
        }
        private Size GetMaxSize(double _ratio)
        {
            double width;
            double height;

            if (OriginalFile.isWide)
            {
                width = MaxDim;
                height = width * _ratio;
                Math.Round(height, 0);
            }
            else
            {
                height = MaxDim;
                width = height * _ratio;
                Math.Round(width, 0);
            }

            return new Size((int)width, (int)height);
        }
        private int GetUsage(bool _show = true)
        {
            decimal nmrHeight = nmr_height.Value;
            decimal nmrWidth = nmr_width.Value;
            int height = Convert.ToInt32(nmrHeight);
            int width = Convert.ToInt32(nmrWidth);
            int useWidth; //1=true; 2=false; 3=NOPE

            if (height == 0)
            {
                useWidth = 1;
            }
            else if (width == 0)
            {
                useWidth = 2;
            }
            else
            {
                useWidth = 3;
                if (_show)
                {
                    MessageBox.Show("You can't change both dimensions at once!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            return useWidth;
        }
        private int GetDimension()
        {      
            decimal dimension = -1m;
            int usage = GetUsage(false);
            decimal nmrWdt = nmr_width.Value;
            decimal nmrHgt = nmr_height.Value;

            if (nmrWdt > MaxDim || nmrHgt > MaxDim)
            {
                MessageBox.Show("Max dimension exceeded;" + Environment.NewLine + "Setting maximum possible dimension...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return MaxDim;
            }

            if (usage == 1) // if usage is 1 => use width
            {
                dimension = nmr_width.Value;
            }
            else if (usage == 2)
            {
                dimension = nmr_height.Value;
            }
            return Convert.ToInt32(dimension);
        }
        private void Save(Bitmap _bitmap)
        {
            if (OriginalFile != null)
            {
                sfd_edited.Filter = Filter;
                ImageFormat format = ImageFormat.Jpeg;

                if (sfd_edited.ShowDialog() == DialogResult.OK)
                {
                    string extension = Path.GetExtension(sfd_edited.FileName);
                    if (!IsFileLocked(sfd_edited.FileName))
                    {
                        switch (extension)
                        {
                            case ".bmp":
                                format = ImageFormat.Bmp;
                                break;
                            case ".jpeg":
                                format = ImageFormat.Jpeg;
                                break;
                            case ".jpg":
                                format = ImageFormat.Jpeg;
                                break;
                            case ".png":
                                format = ImageFormat.Png;
                                break;
                        }
                        _bitmap.Save(sfd_edited.FileName, format);
                        lbl_saved.Visible = true;
                    }
                }
            }
        }
        private bool IsFileLocked(string _filepath)
        {
            FileInfo file = new FileInfo(_filepath);
            FileStream stream = null;
       
            try
            {
                stream = file.Open(FileMode.Open, FileAccess.Write, FileShare.None);
            }
            catch (FileNotFoundException) { }
            catch (IOException)
            {
                MessageBox.Show("The file is locked!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return true;
            }
            finally
            {
                if (stream != null)
                {
                    stream.Close();
                }
            }
            return false;
        }
    }
}
