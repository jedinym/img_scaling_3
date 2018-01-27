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
        Bitmap OriginalFile;
        byte[] StoredBytes;
        string Filter = "Image Files(*.BMP; *.JPEG; *.JPG; *.PNG)|*.BMP; *.JPEG; *.JPG; *.PNG";

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
                //OriginalFile = new Bitmap(originalFilePath);
                StoredBytes = ByteImage.GetBytesFromFilepath(originalFilePath);
                OriginalFile = ByteImage.GetImageFromBytes(StoredBytes);

                Bitmap pictureBoxFile = ScaleDownForPictureBox(OriginalFile);
                pbx_original.Image = pictureBoxFile;
                pbx_edited.Image = pictureBoxFile;
            }
        }
        private void btn_resize_Click(object sender, EventArgs e)
        {
            if (OriginalFile != null)
            {
                pbx_edited.Image = ScaleDownImage(OriginalFile, GetDimension(), GetUsage());
            }
        }
        private void btn_save_Click(object sender, EventArgs e)
        {
            int dimension = GetDimension();
            Bitmap editedImage = ScaleDownImage(OriginalFile, dimension, GetUsage());
            if (dimension != -1)
            {
                Save(editedImage);
            }
        }
        private Bitmap ScaleDownForPictureBox(Bitmap _bitmap)
        {
            double bitmapWidth = _bitmap.Width;
            double bitmapHeight = _bitmap.Height;

            double PictureBoxWidth = pbx_original.Width;
            double PictureBoxHeight = pbx_original.Height;

            double ratio;

            if (bitmapWidth >= bitmapHeight)
            {
                ratio = PictureBoxWidth / bitmapWidth;
            }
            else
            {
                ratio = PictureBoxHeight / bitmapHeight;
            }

            bitmapHeight *= ratio;
            bitmapWidth *= ratio;

            Math.Round(bitmapHeight, 1);
            Math.Round(bitmapWidth, 1);

            Size size = new Size((int)bitmapWidth, (int)bitmapHeight);
            return new Bitmap(_bitmap, size);
        }
        private Bitmap ScaleDownImage(Bitmap _bitmap, int _dimension, int _useWidth)
        {
            if (_useWidth != 3 && _dimension != -1 && _dimension != 0)
            {
                double bitmapWidth = _bitmap.Width;
                double bitmapHeight = _bitmap.Height;

                double ratio = 0;

                if (_useWidth == 1)
                {
                    ratio = _dimension / bitmapWidth;
                }
                else if (_useWidth == 2)
                {
                    ratio = _dimension / bitmapHeight;
                }

                bitmapHeight *= ratio;
                bitmapWidth *= ratio;

                Math.Round(bitmapHeight, 1);
                Math.Round(bitmapWidth, 1);

                Size size = new Size((int)bitmapWidth, (int)bitmapHeight);
                return new Bitmap(_bitmap, size);
            }
            return (Bitmap)pbx_original.Image;        
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

            if (usage == 1)
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
                    //switch (extension)
                    //{
                    //    case ".bmp":
                    //        format = ImageFormat.Bmp;
                    //        break;
                    //    case ".jpeg":
                    //        format = ImageFormat.Jpeg;
                    //        break;
                    //    case ".jpg":
                    //        format = ImageFormat.Jpeg;
                    //        break;
                    //    case ".png":
                    //        format = ImageFormat.Png;
                    //        break;
                    //}
                    //_bitmap.Save(sfd_edited.FileName, format);
                    //lbl_saved.Visible = true;
                }
            }
        }
        
        private bool IsFileLocked(string _filepath)
        {
            FileInfo file = new FileInfo(_filepath);
            Stream stream = null;

            try
            {
                stream = file.Open(FileMode.Open, FileAccess.Write, FileShare.None);
            }
            catch (FileNotFoundException)
            {
                 
            }
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
