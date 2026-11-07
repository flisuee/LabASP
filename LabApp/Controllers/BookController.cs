using LabApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace LabApp.Controllers;

public class BookController : Controller
{
    
    public IActionResult Index()
    {
        return View(BookStoreMemory.Books);
    }
    
    [HttpGet]
    public IActionResult Create()
    {
        return View(new BookFormViewModel());
    }

    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(BookFormViewModel vm)
    {
        if (!ModelState.IsValid)
        {
            return View(vm);
        }

        BookStoreMemory.Books.Add(new Book
        {
            Id = BookStoreMemory.Books.Any()
                ? BookStoreMemory.Books.Max(b => b.Id) + 1
                : 1,
            Title = vm.Title,
            Isbn = vm.Isbn,
            PublicationDate = vm.PublicationDate,
            NumPages = vm.NumPages,
            Price = vm.Price,
            Author = vm.Author
        });

        TempData["Success"] = $"Dodano książkę „{vm.Title}”.";

        return RedirectToAction(nameof(Index));
    }
    
    public async Task ByYear(int year) { /* filtruj listę po roku, zwróć widok Index */ }
    public async Task ByIsbn(string isbn) { /* znajdź książkę, przekieruj na Details lub NotFound() */ }
}