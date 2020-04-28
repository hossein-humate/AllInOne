using Microsoft.AspNetCore.Http;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility.Helpers
{
    public interface IImageWriter
    {
        Task<string> UploadImage(IFormFile file, string directory);
    }

    public class ImageWriter : IImageWriter
    {
        public async Task<string> UploadImage(IFormFile file, string directory)
        {
            if (CheckIfImageFile(file))
            {
                return await WriteFile(file, directory);
            }

            return "فایل تصویر نامعتبر است";
        }

        /// <summary>
        /// Method to check if file is image file
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        private bool CheckIfImageFile(IFormFile file)
        {
            byte[] fileBytes;
            using (MemoryStream ms = new MemoryStream())
            {
                file.CopyTo(ms);
                fileBytes = ms.ToArray();
            }

            return GetImageFormat(fileBytes) != ImageFormat.Unknown;
        }

        /// <summary>
        /// Method to write file onto the disk
        /// </summary>
        /// <param name="file"></param>
        /// <param name="directory"></param>
        /// <returns></returns>
        public async Task<string> WriteFile(IFormFile file, string directory)
        {
            string fileName;
            try
            {
                string extension = "." +
                    file.FileName.Split('.')[file.FileName.Split('.').Length - 1];
                fileName = Guid.NewGuid().ToString() + extension;
                string path = Path.Combine(directory, fileName);

                await using (FileStream bits = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(bits);
                }
            }
            catch (Exception e)
            {
                return e.Message;
            }

            return fileName;
        }

        public enum ImageFormat
        {
            Bmp,
            Jpeg,
            Gif,
            Tiff,
            Png,
            Unknown
        }

        public static ImageFormat GetImageFormat(byte[] bytes)
        {
            byte[] bmp = Encoding.ASCII.GetBytes("BM"); // BMP
            byte[] gif = Encoding.ASCII.GetBytes("GIF"); // GIF
            byte[] png = new byte[] { 137, 80, 78, 71 }; // PNG
            byte[] tiff = new byte[] { 73, 73, 42 }; // TIFF
            byte[] tiff2 = new byte[] { 77, 77, 42 }; // TIFF
            byte[] jpeg = new byte[] { 255, 216, 255, 224 }; // jpeg
            byte[] jpeg2 = new byte[] { 255, 216, 255, 225 }; // jpeg canon

            if (bmp.SequenceEqual(bytes.Take(bmp.Length)))
            {
                return ImageFormat.Bmp;
            }

            if (gif.SequenceEqual(bytes.Take(gif.Length)))
            {
                return ImageFormat.Gif;
            }

            if (png.SequenceEqual(bytes.Take(png.Length)))
            {
                return ImageFormat.Png;
            }

            if (tiff.SequenceEqual(bytes.Take(tiff.Length)))
            {
                return ImageFormat.Tiff;
            }

            if (tiff2.SequenceEqual(bytes.Take(tiff2.Length)))
            {
                return ImageFormat.Tiff;
            }

            if (jpeg.SequenceEqual(bytes.Take(jpeg.Length)))
            {
                return ImageFormat.Jpeg;
            }

            if (jpeg2.SequenceEqual(bytes.Take(jpeg2.Length)))
            {
                return ImageFormat.Jpeg;
            }

            return ImageFormat.Unknown;
        }

        public static Bitmap ResizeAndWriteFile(IFormFile file, int width, int height, string directory)
        {
            Image image = Image.FromStream(file.OpenReadStream());
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);
            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighSpeed;
                graphics.InterpolationMode = InterpolationMode.Low;
                graphics.SmoothingMode = SmoothingMode.HighSpeed;
                graphics.PixelOffsetMode = PixelOffsetMode.HighSpeed;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }
            string fileName;
            string extension = "." +
                               file.FileName.Split('.')[file.FileName.Split('.').Length - 1];
            fileName = Guid.NewGuid() + extension;
            string path = Path.Combine(directory, fileName);
            destImage.Save(path);
            return destImage;
        }
    }
}