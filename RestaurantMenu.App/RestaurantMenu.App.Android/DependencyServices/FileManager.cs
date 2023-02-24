
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using RestaurantMenu.App.DependencyServices;
using RestaurantMenu.App.Droid.DependencyServices;

[assembly: Xamarin.Forms.Dependency(typeof(FileManager))]
namespace RestaurantMenu.App.Droid.DependencyServices
{
    public class FileManager : IFileManager
    {
        public string SaveFile(Stream stream, string fileName)
        {
           var dir = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "Images");

            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            string filename = fileName + ".jpg";
            string filePath = System.IO.Path.Combine(dir.ToString(), filename);

            try
            {
                System.IO.File.WriteAllBytes(filePath, ReadToEnd(stream));
                return filePath;
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message.ToString());
                return null;
            }
        }

        public static byte[] ReadToEnd(System.IO.Stream stream)
        {
            long originalPosition = 0;

            if (stream.CanSeek)
            {
                originalPosition = stream.Position;
                stream.Position = 0;
            }

            try
            {
                byte[] readBuffer = new byte[4096];

                int totalBytesRead = 0;
                int bytesRead;

                while ((bytesRead = stream.Read(readBuffer, totalBytesRead, readBuffer.Length - totalBytesRead)) > 0)
                {
                    totalBytesRead += bytesRead;

                    if (totalBytesRead == readBuffer.Length)
                    {
                        int nextByte = stream.ReadByte();
                        if (nextByte != -1)
                        {
                            byte[] temp = new byte[readBuffer.Length * 2];
                            Buffer.BlockCopy(readBuffer, 0, temp, 0, readBuffer.Length);
                            Buffer.SetByte(temp, totalBytesRead, (byte)nextByte);
                            readBuffer = temp;
                            totalBytesRead++;
                        }
                    }
                }

                byte[] buffer = readBuffer;
                if (readBuffer.Length != totalBytesRead)
                {
                    buffer = new byte[totalBytesRead];
                    Buffer.BlockCopy(readBuffer, 0, buffer, 0, totalBytesRead);
                }
                return buffer;
            }
            finally
            {
                if (stream.CanSeek)
                {
                    stream.Position = originalPosition;
                }
            }
        }
    }
}