using System;
using System.Collections.Generic;
using AvaloniaDemo.Helpers;
using AvaloniaDemo.Models;
using ReactiveUI;

namespace AvaloniaDemo.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        /// <summary>
        /// 当前页面
        /// </summary>
        private PageViewModelBase _CurrentPage;

        /// <summary>
        /// 标题
        /// </summary>
        private string? _Title;

        /// <summary>
        /// 导航菜单按钮list
        /// </summary>
        public List<MenuButtonItem> MenuButtons { get; }
        
        /// <summary>
        /// 标题，显示在主页面上部
        /// </summary>
        public string? Title { 
            get { return _Title; }
            set { this.RaiseAndSetIfChanged(ref _Title, value); }
        }
        
        /// <summary>
        /// 更换当前页面时提醒页面切换
        /// 页面切换的原理使用了反射
        /// </summary>
        public PageViewModelBase CurrentPage
        {
            get { return _CurrentPage; }
            private set { this.RaiseAndSetIfChanged(ref _CurrentPage, value); }
        }

        public MainWindowViewModel()
        {
            MenuButtons = new List<MenuButtonItem>
            {
                new MenuButtonItem(ImageHelper.LoadFromResource(new Uri("avares://AvaloniaDemo/Assets/Img/home.png")), 
                    "首页", ReactiveCommand.Create(HomeButtonClick), new HomePageViewModel()),
                new MenuButtonItem(ImageHelper.LoadFromResource(new Uri("avares://AvaloniaDemo/Assets/Img/img1.png")), 
                    "页面1", ReactiveCommand.Create(Button1Click), new Page1ViewModel()),
                new MenuButtonItem(ImageHelper.LoadFromResource(new Uri("avares://AvaloniaDemo/Assets/Img/img2.png")), 
                    "页面2", ReactiveCommand.Create(Button2Click), new Page2ViewModel()),
                new MenuButtonItem(ImageHelper.LoadFromResource(new Uri("avares://AvaloniaDemo/Assets/Img/img3.png")), 
                    "页面3",ReactiveCommand.Create(Button3Click),new Page3ViewModel())
            };

            //初识默认展示首页界面
            HomeButtonClick();
        }
        
        /// <summary>
        /// 首页按钮点击事件
        /// </summary>
        public void HomeButtonClick()
        {
            CurrentPage = MenuButtons[0].PageView;
            Title = MenuButtons[0].ButtonContent;
        }

        /// <summary>
        /// 按钮1点击事件
        /// </summary>
        public void Button1Click()
        {
            CurrentPage = MenuButtons[1].PageView;
            Title = MenuButtons[1].ButtonContent;
        }

        /// <summary>
        /// 按钮2点击事件
        /// </summary>
        public void Button2Click()
        {
            CurrentPage = MenuButtons[2].PageView;
            Title = MenuButtons[2].ButtonContent;
        }

        /// <summary>
        /// 按钮3点击事件
        /// </summary>
        public void Button3Click()
        {
            CurrentPage = MenuButtons[3].PageView;
            Title = MenuButtons[3].ButtonContent;
        }
    }
}
