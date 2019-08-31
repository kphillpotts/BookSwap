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
        private ColorValues _colors;
        private string _userImage;
        private string _userName;
        private string _description;

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
        public ColorValues Colors
        {
            get { return _colors; }
            set { SetProperty<ColorValues>(ref _colors, value); }
        }
        public string UserImage
        {
            get { return _userImage; }
            set { SetProperty<string>(ref _userImage, value); }
        }
        public string UserName
        {
            get { return _userName; }
            set { SetProperty<string>(ref _userName, value); }
        }

        public string Description
        {
            get { return _description; }
            set { SetProperty<string>(ref _description, value); }
        }


    }
}
