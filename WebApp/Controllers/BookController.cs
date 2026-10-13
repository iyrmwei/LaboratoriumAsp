using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers;

public class BookController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View(BookStoreMemory.Books);
    }
    
    [HttpGet]
    public IActionResult Create() => View(new BookFormViewModel());

    [HttpPost]
    public IActionResult Create(BookFormViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }
        
        BookStoreMemory.Books.Add(new Book
        {
            Id = BookStoreMemory.Books.Max(b => b.Id) + 1,
            Title = model.Title,
            Isbn = model.Isbn,
            Author = model.Author,
            Price = model.Price,
            NumPages = model.NumPages,
            PublicationDate = model.PublicationDate
        });

        TempData["Success"] = $"Dodano książkę '{model.Title}'.";
        return RedirectToAction(nameof(Index));
    }

    public IActionResult Echo(string name, int? count)
    {
        if (count == null)
        {
            return BadRequest();
        }

        ViewBag.Count = count;
        ViewBag.Name = name;
        return View();
    }

    public IActionResult EchoForm()
    {
        return View();
    }
}