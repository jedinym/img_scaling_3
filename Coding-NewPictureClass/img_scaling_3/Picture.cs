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
        public Bitmap bitmap { get; set; }
        public bool isWide { get; private set; }

        public Picture(Bitmap _bitmap)
        {
            bitmap = _bitmap;
            SetIsWide();
        }
        private bool SetIsWide()
        {
            return (bitmap.Width >= bitmap.Height) ? true : false;
        }
    }
}
