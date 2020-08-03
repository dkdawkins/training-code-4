using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PizzaStore.Domain.Models;
using PizzaStore.Storing;

namespace PizzaStore.Client.Controllers
{
  public class PizzaController : Controller
  {
    private readonly PizzaStoreDbContext _db;

    public PizzaController(PizzaStoreDbContext dbContext) //constructor dependecy injection
    {
      _db = dbContext;
    }

    [HttpGet()] // action filters (authorization/authentication, action, resource, response, exception)
    public IActionResult Get()  // /pizza/get
    {
      // ViewData, TempData (dictionaries)
      // ViewBag.PizzaList = _db.Pizzas.ToList();  // dynamic object

      // ViewData["PizzaList"] = _db.Pizzas.ToList();
      // TempData["PizzaList"] = _db.Pizzas.ToList(); // survives until end of request; used with redirection

      return View("Home2", _db.Pizzas.ToList());
      //return View("Home");
    }

    [HttpGet("{id}")]
    public PizzaModel Get(int id) // /pizza/get/<id>
    {
      return _db.Pizzas.SingleOrDefault(p => p.Id == id);
    }
  }
}