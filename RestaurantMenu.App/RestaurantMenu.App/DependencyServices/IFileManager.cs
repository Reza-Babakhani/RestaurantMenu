
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantMenu.App.DependencyServices
{
    public interface IFileManager
    {
        //return path
        string SaveFile(Stream stream, string fileName);
    }
}
