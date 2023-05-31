using System.Drawing;
using System.Drawing.Imaging;

namespace tester.api.Helpers
{
    public class CustomHelpers
    {
        public static Bitmap Base64ToBitmap(string data)
        {
            try
            {
                Bitmap bmpReturn = null;
                byte[] byteBuffer = Convert.FromBase64String(data.Substring(data.IndexOf(",") + 1));
                using (var ms = new MemoryStream(byteBuffer))
                {
                    bmpReturn = (Bitmap)Bitmap.FromStream(ms);
                }
                return bmpReturn;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static async Task<Bitmap> ResizeImage(Bitmap original, int width, int height)
        {
            try
            {
                Bitmap resizedImage;

                int rectHeight = width;
                int rectWidth = height;

                if (original.Height == original.Width)
                {
                    resizedImage = new Bitmap(original, rectHeight, rectHeight);
                }
                else
                {
                    float aspect = original.Width / (float)original.Height;
                    int newWidth, newHeight;
                    newWidth = (int)(rectWidth * aspect);
                    newHeight = (int)(newWidth / aspect);

                    if (newWidth > rectWidth || newHeight > rectHeight)
                    {
                        if (newWidth > newHeight)
                        {
                            newWidth = rectWidth;
                            newHeight = (int)(newWidth / aspect);
                        }
                        else
                        {
                            newHeight = rectHeight;
                            newWidth = (int)(newHeight * aspect);
                        }
                    }
                    resizedImage = new Bitmap(original, newWidth, newHeight);
                }
                return resizedImage;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static string PathFromUserID(string ID)
        {
            return "/" + string.Join("/", ID.ToArray()) + "/";
        }

        public static bool WriteImage(Bitmap bitmap, string path, string filename)
        {
            try
            {
                Directory.CreateDirectory(path);
                using (Bitmap bmp = new Bitmap(bitmap))
                {
                    bmp.Save(path + filename, ImageFormat.Jpeg);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static async Task<string> SaveAvatar(int ID, string envPath, string data)
        {
            try
            {
                var original = Base64ToBitmap(data);
                var resized = await ResizeImage(original, 600, 600);
                var avatarPath = PathFromUserID(ID.ToString());
                var savePath = envPath + "/media/avatars" + avatarPath;
                var fileName = "avatar.jpg";

                if (resized != null)
                {
                    var written = WriteImage(resized, savePath, fileName);

                    if (written)
                    {
                        return avatarPath + fileName;
                    }
                }

                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}