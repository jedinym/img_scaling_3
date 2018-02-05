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
        public bool IsWide { get; private set; }
        public double RatioWh { get; private set; }
        public double RatioHw { get; private set; }
        public int Width { get; private set; }
        public int Heigth { get; private set; }

        public Picture(Bitmap _bitmap)
        {
            Bitmap = _bitmap;
            SetIsWide();
            SetRatios();
            Width = Bitmap.Width;
            Heigth = Bitmap.Height;
        }
        private void SetIsWide()
        {
            try
            {
                //return (Bitmap.Width >= Bitmap.Height) ? true : false;
                IsWide = (Bitmap.Width >= Bitmap.Height) ? true : false;
            }
            catch (NullReferenceException)
            {
                IsWide = false;
                //return false;
            }
        }

        private void SetRatios()
        {
            try
            {
                RatioWh = (double)Bitmap.Width / (double)Bitmap.Height;
                RatioHw = (double)Bitmap.Height / (double)Bitmap.Width;
                //return (Bitmap.Width >= Bitmap.Height) ? (double)Bitmap.Height/(double)Bitmap.Width : (double)Bitmap.Width/(double)Bitmap.Height;
                //return (double)Bitmap.Width / (double)Bitmap.Height;
            }
            catch (NullReferenceException)
            {
                //return 0;
                RatioWh = 0;
                RatioHw = 0;
            }
        }
        static public string SetSizeLabel(Image _bitmap)
        {
            string width = Convert.ToString(_bitmap.Width);
            string height = Convert.ToString(_bitmap.Height);

            return string.Format("{0} x {1}", width, height);
        }
    }
}
