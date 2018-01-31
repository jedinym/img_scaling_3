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
        public double ratio { get; private set; }

        public Picture(Bitmap _bitmap)
        {
            Bitmap = _bitmap;
            isWide = SetIsWide();
            ratio = SetRatio();
        }
        private bool SetIsWide()
        {
            try
            {
                return (Bitmap.Width >= Bitmap.Height) ? true : false;
            }
            catch (NullReferenceException)
            {
                return false;
            }
        }

        private double SetRatio()
        {
            try
            {
                //return (Bitmap.Width >= Bitmap.Height) ? (double)Bitmap.Height/(double)Bitmap.Width : (double)Bitmap.Width/(double)Bitmap.Height;
                return (double)Bitmap.Width / (double)Bitmap.Height;
            }
            catch (NullReferenceException)
            {
                return 0;
            }  
        }
    }
}
