using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace img_scaling_3
{
    public class Picture
    {
        public Bitmap Bitmap { get; set; }
        public bool isWide { get; private set; }
        public double ratioWH { get; private set; }
        public double ratioHW { get; private set; }

        public Picture(Bitmap _bitmap)
        {
            Bitmap = _bitmap;
            SetIsWide();
            SetRatios();
        }
        private void SetIsWide()
        {
            try
            {
                //return (Bitmap.Width >= Bitmap.Height) ? true : false;
                isWide = (Bitmap.Width >= Bitmap.Height) ? true : false;
            }
            catch (NullReferenceException)
            {
                isWide = false;
                //return false;
            }
        }

        private void SetRatios()
        {
            try
            {
                ratioWH = (double)Bitmap.Width / (double)Bitmap.Height;
                ratioHW = (double)Bitmap.Height / (double)Bitmap.Width;
                //return (Bitmap.Width >= Bitmap.Height) ? (double)Bitmap.Height/(double)Bitmap.Width : (double)Bitmap.Width/(double)Bitmap.Height;
                //return (double)Bitmap.Width / (double)Bitmap.Height;
            }
            catch (NullReferenceException)
            {
                //return 0;
                ratioWH = 0;
                ratioHW = 0;
            }
        }
    }
}
