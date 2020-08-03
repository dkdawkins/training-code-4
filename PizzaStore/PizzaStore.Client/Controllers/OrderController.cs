using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PizzaStore.Client.Models;
using PizzaStore.Domain.Factories;
using PizzaStore.Domain.Models;
using PizzaStore.Storing;

namespace PizzaStore.Client.Controllers
{
  public class OrderController : Controller
  {
    private readonly PizzaStoreDbContext _db;

    public OrderController(PizzaStoreDbContext dbContext) //constructor dependecy injection
    {
      _db = dbContext;
    }

    public IActionResult Home() // /order/home
    {
      return View("Order", new PizzaViewModel());
    }

    [HttpPost]
    public IActionResult PlaceOrder(PizzaViewModel pizzaViewModel) //model binding
    {
      if (ModelState.IsValid) //what is validation? (Add to viewmodel)
      {
        var p = new PizzaFactory(); //use dependency injection instead of new

        //p.Create(pizzaViewModel);
        //repository.Create(pizzaViewModel);
        return View();
      }

      return View("Order", pizzaViewModel);
    }
  }
}