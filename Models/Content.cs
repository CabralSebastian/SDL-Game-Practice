using System;
using System.Collections.Generic;
using System.IO;
using Tao.Sdl;

namespace MyGame.Models
{
    internal class Content
    {
        private readonly string ImagesDir = "Assets/Images/";
        private readonly Dictionary<string, Image> images;

        internal Content()
        {
            images = new Dictionary<string, Image>();
        }

        internal void Load()
        {
            /* LOAD IMAGES */
            string[] imagesPaths = Directory.GetFiles(ImagesDir);

            foreach (string imagesPath in imagesPaths)
            {
                string ImageName = Path.GetFileName(imagesPath).Split('.')[0];
                LoadImage(imagesPath, ImageName);
            } 
        }

        private void LoadImage(string imagePath, string key)
        {
            Image image = new Image(SdlImage.IMG_Load(imagePath));

            if (image.Pointer == IntPtr.Zero)
            {
                Console.WriteLine("Imagen inexistente: {0}", imagePath);
                Environment.Exit(4);
            }

            images.Add(key, image);
        }

        internal Image GetImage(string key)
        {
            return images.TryGetValue(key, out Image image) ? image : null;
        }
    }
}

