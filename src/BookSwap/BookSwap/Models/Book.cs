using BookSwap.Cells;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookSwap.Models
{
    public class Book : ObservableObject
    {
        private string _title;
        private string _author;
        private string _coverImage;
        private string _accentColor;

        public string Title
        {
            get { return _title; }
            set { SetProperty<string>(ref _title, value); }
        }

        public string Author
        {
            get { return _author; }
            set { SetProperty<string>(ref _author, value); }
        }

        public string CoverImage
        {
            get { return _coverImage; }
            set { SetProperty<string>(ref _coverImage, value); }
        }
        public string AccentColor
        {
            get { return _accentColor; }
            set { SetProperty<string>(ref _accentColor, value); }
        }

    }
}
