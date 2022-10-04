using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormCharpWebCam
{
    class Helper
    {
        public static void SaveImageCapture(Image image)
        {

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.FileName = "Image";// Default file name
            sfd.Filter = "JPEG|*.jpg|PNG|*.png"; // Filter files by extension          

            // Show save file dialog box
            // Process save file dialog box results
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                // Save Image
                string filename = sfd.FileName;
                FileStream fstream = new FileStream(filename, FileMode.Create);
                image.Save(fstream, System.Drawing.Imaging.ImageFormat.Jpeg);
                fstream.Close();
            }
        }
    }
}
