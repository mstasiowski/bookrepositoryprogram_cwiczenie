using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bookrepositoryprogram.Models;
using Microsoft.AspNetCore.Http;

namespace bookrepositoryprogram.Controllers
{
    public class BookController : Controller
    {
        public static List<book> books = new List<book>()
        {
            new book(){Id=1, Title="Hobbit", Author="J.R.R. Tolkien", PublishingYear=1937, Price=29},
            new book(){Id=2, Title="Lord of the rings", Author="J.R.R. Tolkien", PublishingYear=1954, Price=31},
            new book(){Id=3, Title="Metro 2033", Author="Dmitrij Głuchowski", PublishingYear=2002, Price=30}

        };

        static int index = 4;

        
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddBook()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(book book)
        {
            if (ModelState.IsValid)
            {
                book.Id = index++;
                books.Add(book);
                return View("ConfirmBook", book);
            }
            else
            {
                return View("AddBook");
            }
        }
        [HttpGet]
        public IActionResult List()
        {
            return View(books);
        }

        
        public IActionResult Delete(book book)
        {
            /*   book found = null;
               foreach(var book in books)
               {
                   if(book.Id == id)
                   {
                       found = book;
                       break;
                   }

                   if(found != null)
                   {
                       books.Remove(found);
                   }

               }*/
            var found = books.Find(c => c.Id == book.Id);
            if (found != null)
            {
                books.Remove(found);
            }
            return View("List", books);
        }

        
        public IActionResult EditBook(int id)
        {
            return View();
        }

        public IActionResult Edit(book book)
        {
            var find = books.Find(c => c.Id == book.Id);
            if(find != null)
            {
                find.Title = book.Title;
                find.Author = book.Author;
                find.PublishingYear = book.PublishingYear;
                find.Price = book.Price;
                return View("List", books);
            }else
            {
                throw new NotImplementedException();
            }

        }


    }
}
