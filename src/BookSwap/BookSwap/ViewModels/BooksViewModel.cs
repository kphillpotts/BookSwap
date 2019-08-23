using BookSwap.Models;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace BookSwap.ViewModels
{
    public class BooksViewModel : ObservableObject
    {
        public IList<Book> Books { get; set; }

        public BooksViewModel()
        {
            Books = new ObservableCollection<Book>()
            {
                new Book()
                {
                    Title = "Everything is Illuminated",
                    Author = "Jonathan Safran Foer",
                    AccentColor = "#0FF4C3",
                    CoverImage = "book_illumated",
                },
                new Book()
                {
                    Title = "Ulysses",
                    Author = "James Joyce",
                    AccentColor = "#B76EFE",
                    CoverImage = "book_ulysses",
                },
                new Book()
                {
                    Title = "Flowers for Algernon",
                    Author = "Daniel Keyes",
                    AccentColor = "#FF848B",
                    CoverImage = "book_flowers",
                },
                new Book()
                {
                    Title = "Everything is Illuminated",
                    Author = "Jonathan Safran Foer",
                    AccentColor = "#0FF4C3",
                    CoverImage = "book_illumated",
                },
                new Book()
                {
                    Title = "Ulysses",
                    Author = "James Joyce",
                    AccentColor = "#B76EFE",
                    CoverImage = "book_ulysses",
                },
                new Book()
                {
                    Title = "Flowers for Algernon",
                    Author = "Daniel Keyes",
                    AccentColor = "#FF848B",
                    CoverImage = "book_flowers",
                },
                new Book()
                {
                    Title = "Everything is Illuminated",
                    Author = "Jonathan Safran Foer",
                    AccentColor = "#0FF4C3",
                    CoverImage = "book_illumated",
                },
                new Book()
                {
                    Title = "Ulysses",
                    Author = "James Joyce",
                    AccentColor = "#B76EFE",
                    CoverImage = "book_ulysses",
                },
                new Book()
                {
                    Title = "Flowers for Algernon",
                    Author = "Daniel Keyes",
                    AccentColor = "#FF848B",
                    CoverImage = "book_flowers",
                },
            };
        }
    }
}
