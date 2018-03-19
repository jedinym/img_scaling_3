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
        //Bitmap OriginalFile;
        Picture OriginalFile;
        byte[] StoredBytes;
        string Filter = "Image Files(*.BMP; *.JPEG; *.JPG; *.PNG)|*.BMP; *.JPEG; *.JPG; *.PNG|All Files(*.*)|*.*";

        public frm_main()
        {
            InitializeComponent();
        }

        private void frm_main_Load(object sender, EventArgs e)
        {
            //btn_load.MouseEnter += InfoEvent;
            foreach (Control c in Controls) // Looping through all controls to attach MouseEnter to InfoEvent events
            {
                c.MouseEnter += ShowInfoEvent;
                c.MouseLeave += HideInfoEvent;
            }
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
                    btn_resize.Enabled = true;
                    OriginalFile = new Picture(ByteImage.GetImageFromBytes(StoredBytes));
                    Bitmap pictureBoxFile = ScaleDownForPictureBox();
                    pbx_original.Image = pictureBoxFile;
                    lbl_orig_size.Visible = true;
                    lbl_orig_size.Text = Picture.SetSizeLabel(OriginalFile.Bitmap);
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
                lbl_edit_size.Visible = true;
                lbl_edit_size.Text = Picture.SetSizeLabel(pbx_edited.Image);
                btn_reset.Enabled = true;
                btn_save.Enabled = true;
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
        private void btn_reset_Click(object sender, EventArgs e)
        {
            pbx_edited.Image = pbx_original.Image;
            lbl_edit_size.Text = Picture.SetSizeLabel(OriginalFile.Bitmap);
        }
        private Bitmap ScaleDownForPictureBox()
        {
            double bitmapWidth = OriginalFile.Bitmap.Width;
            double bitmapHeight = OriginalFile.Bitmap.Height;

            double pictureBoxWidth = pbx_original.Width;
            double pictureBoxHeight = pbx_original.Height;

            double ratio = (OriginalFile.IsWide) ? pictureBoxWidth / bitmapWidth : pictureBoxHeight / bitmapHeight;

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

                double newWidth;
                double newHeight;

                Size size;

                if (OriginalFile.IsWide)
                {

                    //image is wider than taller
                    if (_useWidth == 2)
                    {
                        //use height setting
                        newHeight = (double)nmr_height.Value;

                        if (newHeight * OriginalFile.RatioWh > MaxDim)
                        {
                            newWidth = MaxDim;
                            newHeight = newWidth * OriginalFile.RatioHw;
                        }
                        else
                        {
                            newWidth = ((newHeight * OriginalFile.RatioWh) < 1) ? 1 : newHeight * OriginalFile.RatioWh;
                        }
                    }
                    else
                    {
                        //use width setting
                        newWidth = (double)nmr_width.Value;

                        if (newWidth > MaxDim)
                        {
                            newWidth = MaxDim;
                        }

                        newHeight = newWidth * OriginalFile.RatioHw;
                    }
                }
                else
                {
                    //image is taller than wider
                    if (_useWidth == 2)
                    {
                        //use height setting
                        newHeight = (double)nmr_height.Value;

                        if (newHeight > MaxDim)
                        {
                            newHeight = MaxDim;
                        }

                        newWidth = newHeight * OriginalFile.RatioWh;
                    }
                    else
                    {
                        //use width setting
                        newWidth = (double)nmr_width.Value;

                        if (newWidth * OriginalFile.RatioHw > MaxDim)
                        {
                            newHeight = MaxDim;
                            newWidth = newHeight * OriginalFile.RatioWh;
                        }
                        else
                        {
                            newHeight = ((newWidth * OriginalFile.RatioHw) < 1) ? 1 : newWidth * OriginalFile.RatioHw;
                        }

                    }
                }

                size = new Size((int)newWidth, (int)newHeight);

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

        private void ShowInfoEvent(object sender, EventArgs e)
        {
            Control obj = (Control)sender;
            string ctrlInfo;

            try //If the control doesn't have a tag --> don't crash and erase Info
            {
                ctrlInfo = obj.Tag.ToString(); 
            }
            catch (NullReferenceException)
            {
                ctrlInfo = "";
            }

            lbl_info.Text = ctrlInfo;
        }

        private void HideInfoEvent(object sender, EventArgs e)
        {
            lbl_info.Text = "";
        }
    }
}
