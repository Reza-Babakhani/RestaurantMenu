
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantMenu.App.DependencyServices
{
    public interface IPhotoPicker
    {
        Task<Stream> GetImageStreamAsync();
    }
}

