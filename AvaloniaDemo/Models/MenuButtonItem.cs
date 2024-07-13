using Avalonia.Media;
using Avalonia.Media.Imaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using AvaloniaDemo.ViewModels;

namespace AvaloniaDemo.Models
{
    /// <summary>
    /// 展示菜单按钮信息
    /// </summary>
    public class MenuButtonItem
    {
        /// <summary>
        /// 按钮的图标地址
        /// </summary>
        public Bitmap? ImagSource { get; set; }

        /// <summary>
        /// 按钮显示的文字
        /// </summary>
        public string? ButtonContent { get; set; }

        /// <summary>
        /// 按钮点击事件处理
        /// </summary>
        public ICommand CommandEvent { get; set; }

        /// <summary>
        /// 导航按钮对应的页面
        /// </summary>
        public PageViewModelBase PageView { get; set; }

        public MenuButtonItem(Bitmap? img, string? content, ICommand cmd, PageViewModelBase page)
        {
            ImagSource = img;
            ButtonContent = content;
            CommandEvent = cmd;
            PageView = page;
        }
    }
}
