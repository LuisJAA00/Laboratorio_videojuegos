using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CanvasBased
{
    internal class Canvas
    {
        Size size;

        public Bitmap bitmap;
        public float Width, Height;
        public byte[] bits;
        Graphics g;
        int pixelFormatSize, stride;
        public Canvas(Size size) { 
            this.Init(size.Width, size.Height);
        }

       

        public void DrawPixel(int x, int y, Color c)
        {
            int res = (int)((x*pixelFormatSize) + (y*stride));

            bits[res + 0] = c.B;
            bits[res + 1] = c.G;
            bits[res + 2] = c.R;
            bits[res + 3] = c.A;
        }

        public void Init(int width, int height)
        {
            PixelFormat format;
            GCHandle handle;
            IntPtr bitPointer;
            int padding;

            format = PixelFormat.Format32bppArgb;
            bitmap = new Bitmap(width, height);
            this.Width = width;
            this.Height = height;
            pixelFormatSize = Image.GetPixelFormatSize(format)/8;
            stride = width * pixelFormatSize;
            padding = (stride%4);
            stride += padding == 0 ? 0 : 4 - padding;
            bits = new byte[stride*height];
            handle = GCHandle.Alloc(bits, GCHandleType.Pinned);
            bitPointer = Marshal.UnsafeAddrOfPinnedArrayElement(bits, 0);
            bitmap = new Bitmap(width,height,stride,format,bitPointer);

            g = Graphics.FromImage(bitmap);
        }

        public void FastClear()
        {
            unsafe
            {
                BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                    ImageLockMode.ReadWrite, bitmap.PixelFormat);

                int bytesPerPixel = System.Drawing.Bitmap.GetPixelFormatSize(bitmap.PixelFormat)/8;
                int heightInPixels = bitmapData.Height;
                int widthInBytes = bitmapData.Width * bytesPerPixel;
                byte* pointerFirstPixel = (byte*)bitmapData.Scan0;

                Parallel.For(
                    0,
                    heightInPixels,
                    y =>
                    {
                        byte* bits = pointerFirstPixel + (y*bitmapData.Stride);
                        for(int x = 0; x < widthInBytes; x += bytesPerPixel )
                        {
                            bits[x + 0] = 0;
                            bits[x + 1] = 0;
                            bits[x + 2] = 0;
                            bits[x + 3] = 0;
                        }
                    });

                bitmap.UnlockBits(bitmapData);
            }
        }

        public void DrawLine(Point p1,Point p2, Color c)
        {
            g.DrawLine(new Pen(c),p1,p2);
        }
    }
}
