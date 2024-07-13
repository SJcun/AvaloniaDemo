using Avalonia.Media.Imaging;
using Avalonia.Platform;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaDemo.Helpers
{
    /// <summary>
    /// 图像助手
    /// 参考官网https://docs.avaloniaui.net/zh-Hans/docs/guides/data-binding/how-to-bind-image-files
    /// </summary>
    public static class ImageHelper
    {
        /// <summary>
        /// 从本地路径读取图像资源
        /// </summary>
        /// <param name="resourceUri"></param>
        /// <returns></returns>
        public static Bitmap LoadFromResource(Uri resourceUri)
        {
            return new Bitmap(AssetLoader.Open(resourceUri));
        }

        /// <summary>
        /// 从网络环境读取图像资源
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static async Task<Bitmap?> LoadFromWeb(Uri url)
        {
            using var httpClient = new HttpClient();
            try
            {
                var response = await httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();
                var data = await response.Content.ReadAsByteArrayAsync();
                return new Bitmap(new MemoryStream(data));
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"An error occurred while downloading image '{url}' : {ex.Message}");
                return null;
            }
        }
    }
}
