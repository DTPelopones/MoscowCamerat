using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MoscowCamerat.Domain;

namespace MoscowCamerat.Controllers
{

    public static class Imager
    {
        /// <summary>  
        /// Save image as jpeg  
        /// </summary>  
        /// <param name="path">path where to save</param>  
        /// <param name="img">image to save</param>  
        public static void SaveJpeg(string path, Image img)
        {
            var qualityParam = new EncoderParameter(Encoder.Quality, 100L);
            var jpegCodec = GetEncoderInfo("image/jpeg");

            var encoderParams = new EncoderParameters(1);
            encoderParams.Param[0] = qualityParam;
            img.Save(path, jpegCodec, encoderParams);
        }

        /// <summary>  
        /// Save image  
        /// </summary>  
        /// <param name="path">path where to save</param>  
        /// <param name="img">image to save</param>  
        /// <param name="imageCodecInfo">codec info</param>  
        public static void Save(string path, Image img, ImageCodecInfo imageCodecInfo)
        {
            var qualityParam = new EncoderParameter(Encoder.Quality, 100L);

            var encoderParams = new EncoderParameters(1);
            encoderParams.Param[0] = qualityParam;
            img.Save(path, imageCodecInfo, encoderParams);
        }

        /// <summary>  
        /// get codec info by mime type  
        /// </summary>  
        /// <param name="mimeType"></param>  
        /// <returns></returns>  
        public static ImageCodecInfo GetEncoderInfo(string mimeType)
        {
            return ImageCodecInfo.GetImageEncoders().FirstOrDefault(t => t.MimeType == mimeType);
        }

        /// <summary>  
        /// the image remains the same size, and it is placed in the middle of the new canvas  
        /// </summary>  
        /// <param name="image">image to put on canvas</param>  
        /// <param name="width">canvas width</param>  
        /// <param name="height">canvas height</param>  
        /// <param name="canvasColor">canvas color</param>  
        /// <returns></returns>  
        public static Image PutOnCanvas(Image image, int width, int height, Color canvasColor)
        {
            var res = new Bitmap(width, height);
            using (var g = Graphics.FromImage(res))
            {
                g.Clear(canvasColor);
                var x = (width - image.Width) / 2;
                var y = (height - image.Height) / 2;
                g.DrawImageUnscaled(image, x, y, image.Width, image.Height);
            }

            return res;
        }

        /// <summary>  
        /// the image remains the same size, and it is placed in the middle of the new canvas  
        /// </summary>  
        /// <param name="image">image to put on canvas</param>  
        /// <param name="width">canvas width</param>  
        /// <param name="height">canvas height</param>  
        /// <returns></returns>  
        public static Image PutOnWhiteCanvas(Image image, int width, int height)
        {
            return PutOnCanvas(image, width, height, Color.White);
        }

        /// <summary>  
        /// resize an image and maintain aspect ratio  
        /// </summary>  
        /// <param name="image">image to resize</param>  
        /// <param name="newWidth">desired width</param>  
        /// <param name="maxHeight">max height</param>  
        /// <param name="onlyResizeIfWider">if image width is smaller than newWidth use image width</param>  
        /// <returns>resized image</returns>  
        public static Image Resize(Image image, int newWidth, int maxHeight, bool onlyResizeIfWider)
        {
            if (onlyResizeIfWider && image.Width <= newWidth) newWidth = image.Width;

            var newHeight = image.Height * newWidth / image.Width;
            if (newHeight > maxHeight)
            {
                // Resize with height instead  
                newWidth = image.Width * maxHeight / image.Height;
                newHeight = maxHeight;
            }

            var res = new Bitmap(newWidth, newHeight);

            using (var graphic = Graphics.FromImage(res))
            {
                graphic.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphic.SmoothingMode = SmoothingMode.HighQuality;
                graphic.PixelOffsetMode = PixelOffsetMode.HighQuality;
                graphic.CompositingQuality = CompositingQuality.HighQuality;
                graphic.DrawImage(image, 0, 0, newWidth, newHeight);
            }

            return res;
        }

        /// <summary>  
        /// Crop an image   
        /// </summary>  
        /// <param name="img">image to crop</param>  
        /// <param name="cropArea">rectangle to crop</param>  
        /// <returns>resulting image</returns>  
        public static Image Crop(Image img, Rectangle cropArea)
        {
            var bmpImage = new Bitmap(img);
            var bmpCrop = bmpImage.Clone(cropArea, bmpImage.PixelFormat);
            return bmpCrop;
        }

        public static byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            return ms.ToArray();
        }

        public static Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }

        //The actual converting function  
        public static string GetImage(object img)
        {
            return "data:image/jpg;base64," + Convert.ToBase64String((byte[])img);
        }


        public static void PerformImageResizeAndPutOnCanvas(string pFilePath, string pFileName, int pWidth, int pHeight, string pOutputFileName)
        {

            System.Drawing.Image imgBef;
            imgBef = System.Drawing.Image.FromFile(pFilePath + pFileName);


            System.Drawing.Image _imgR;
            _imgR = Imager.Resize(imgBef, pWidth, pHeight, true);


            System.Drawing.Image _img2;
            _img2 = Imager.PutOnCanvas(_imgR, pWidth, pHeight, System.Drawing.Color.White);

            //Save JPEG  
            Imager.SaveJpeg(pFilePath + pOutputFileName, _img2);

        }
    }

    public class CmsController : BaseController
    {
        // GET: Cms
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CmsPart()
        {
            IEnumerable<Photo> photoes = null;
            photoes = repository.Photo.Where(f => f.album.Contains("Афиша")).OrderByDescending(f => f.sort).Take(3);

            return PartialView("CmsPart", photoes);
        }

        public ImageCodecInfo GetEncoderInfo(string mimeType)
        {
            return ImageCodecInfo.GetImageEncoders().FirstOrDefault(t => t.MimeType == mimeType);
        }

        public Image resizeImage(Image imgToResize, Size size)
        {
            return (Image)(new Bitmap(imgToResize, size));
        }

        [HttpPost]
        public ActionResult Upload(Photo photo, HttpPostedFileBase upload)
        {
            if (upload != null)
            {
                // получаем имя файла
                string fileName = System.IO.Path.GetFileName(upload.FileName);

                if (fileName.Contains(".jpg") || fileName.Contains(".jpeg"))
                {
                    photo.album = "Афиша"; 
                    photo.alt = photo.album + " - " + photo.eventDesc;
                    photo.eventDay = photo.dateConcert.ToString("dd");
                    photo.eventMonthYear = photo.dateConcert.ToString(".MM.yyyy");
                    photo.eventTime = photo.dateConcert.ToString("HH:mm");

                    if (photo.sort == null)
                    {
                        photo.sort = repository.SqlQueryGetInt("select max(p.[sort]) as [sort] from dbo.Photo as p with(nolock) where p.[album] = N'Афиша'") + 3;
                    }
                    string newFileName = photo.dateConcert.ToString("yyyy") + photo.dateConcert.ToString("MM") + photo.dateConcert.ToString("dd") + ".jpg"; 
                    fileName = fileName.Replace(".jpeg", ".jpg");

                    // сохраняем файл в папку Files в проекте
                    upload.SaveAs(Server.MapPath("~/img/Afisha/" + newFileName));
                    photo.path = "../img/Afisha/" + newFileName.ToLower();
                    photo.pathm = "../img/Afisha/" + newFileName.ToLower().Replace(".jpg","m.jpg");
                    
                    System.Drawing.Image image = System.Drawing.Image.FromFile(Server.MapPath("~/img/Afisha/" + newFileName));
                    int ActualWidth = image.Width;
                    int ActualHeight = image.Height;

                    photo.size = ActualWidth.ToString() + "x" + ActualHeight.ToString();

                    /*Cut*/
                    double newHeight = 0;
                    double newWidth = 0;
                    double scale = 0;
                    int size = 276; 

                    //create new image object
                    Bitmap curImage = new Bitmap(Server.MapPath("~/img/Afisha/" + newFileName));

                    //Determine image scaling
                    if (curImage.Height < curImage.Width)
                    {
                        scale = Convert.ToSingle(size) / curImage.Height;
                    }
                    else
                    {
                        scale = Convert.ToSingle(size) / curImage.Width;
                    }

                    if (scale < 0 || scale > 1)
                    {
                        scale = 1;
                    } 

                    //New image dimension
                    newHeight = Math.Floor(Convert.ToSingle(curImage.Height) * scale);
                    newWidth = Math.Floor(Convert.ToSingle(curImage.Width) * scale);
                    curImage.Dispose();
                    image.Dispose();
                    Imager.PerformImageResizeAndPutOnCanvas(Server.MapPath("~/img/Afisha/"), newFileName, Convert.ToInt16(newWidth), Convert.ToInt16(newHeight), newFileName.ToLower().Replace(".jpg", "m.jpg"));

                    photo.sizem = Convert.ToInt16(newWidth).ToString() + "x" + Convert.ToInt16(newHeight).ToString(); 


                    repository.CreatePhoto(photo);
                } 
            }
            return RedirectToAction("../Afisha");
        }
    }
}