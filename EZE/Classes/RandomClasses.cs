using Bunifu.Framework.UI;
using MetroFramework.Controls;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace EZE
{
    public class MyButton : Button //Custom button that isn't TAB affected
    {
        protected override bool ShowFocusCues
        {
            get
            {
                return false;
            }
        }
    }
    public class MyGunaButton : Guna2Button //Custom button that isn't TAB affected
    {
        protected override bool ShowFocusCues
        {
            get
            {
                return false;
            }
        }
    }

    public class MyGunaMetroGrid : Guna2DataGridView //Custom gunadatagridview that isn't TAB affected
    {
        protected override bool ShowFocusCues
        {
            get
            {
                return false;
            }
        }
    }   
    public class CropToCircle //To make a circle picturebox effect
    {
        public static Image croptocircle(Image srcImage, Size size, Color BackColor)
        {
            Image Canvas = new Bitmap(size.Width, size.Height, srcImage.PixelFormat);
            Graphics g = Graphics.FromImage(Canvas);

            Rectangle outerRect = new Rectangle(-1, -1, Canvas.Width + 1, Canvas.Height + 1);
            Rectangle rect = Rectangle.Inflate(outerRect, -2, -2);

            g.DrawImage(srcImage, outerRect);

            using (SolidBrush brush = new SolidBrush(BackColor))
            using (GraphicsPath path = new GraphicsPath())
            {
                g.InterpolationMode = InterpolationMode.HighQualityBilinear;
                g.CompositingQuality = CompositingQuality.HighQuality;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                g.SmoothingMode = SmoothingMode.AntiAlias;
                path.AddEllipse(rect);
                path.AddRectangle(outerRect);
                g.FillPath(brush, path);
            }
            return Canvas;
        }
    }
    //public class CropToCircleButton //To make a circle picturebox effect
    //{
    //    public static Button croptocirclebutton(Button srcImage)
    //    {
    //        Button Canvas = new Button();

    //        Rectangle outerRect = new Rectangle(-1, -1, Canvas.Width + 1, Canvas.Height + 1);
    //        Rectangle rect = Rectangle.Inflate(outerRect, -2, -2);

    //        g.DrawImage(srcImage, outerRect);

    //        using (SolidBrush brush = new SolidBrush(BackColor))
    //        using (GraphicsPath path = new GraphicsPath())
    //        {
    //            srcImage.InterpolationMode = InterpolationMode.HighQualityBilinear;
    //            g.CompositingQuality = CompositingQuality.HighQuality;
    //            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
    //            g.SmoothingMode = SmoothingMode.AntiAlias;

    //            path.AddEllipse(rect);
    //            path.AddRectangle(outerRect);

    //            g.FillPath(brush, path);
    //        }
    //        return Canvas;
    //    }
    //}
    //To restore the app if it is minimized
    //public static class Extensions
    //{
    //    [DllImport("user32.dll")]
    //    private static extern int ShowWindow(IntPtr hWnd, uint Msg);

    //    private const uint SW_RESTORE = 0x09;

    //    public static void Restore(Form form)
    //    {
    //        if (form.WindowState == FormWindowState.Minimized)
    //        {
    //            ShowWindow(form.Handle, SW_RESTORE);
    //        }
    //    }
    //}
}
