using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using PizzaStore.Client.Models;
using PizzaStore.Domain.Factories;
using PizzaStore.Domain.Models;
using PizzaStore.Storing;

namespace PizzaStore.Client.Controllers
{
  [Route("/[controller]/[action]")] //Can also use /[controller] and name functions after CRUD
  [EnableCors("private")] //See startup.cs for details; can switch to default
  public class OrderController : Controller
  {
    private readonly PizzaStoreDbContext _db;

    public OrderController(PizzaStoreDbContext dbContext) //constructor dependecy injection
    {
      _db = dbContext;
    }

    //[Route("/home")]  //Avoid doing this and controller level routing
    public IActionResult Home() // listens to any http verb; /order/home
    {
      return View("Order", new PizzaViewModel());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult PlaceOrder(PizzaViewModel pizzaViewModel) //model binding
    {
      if (ModelState.IsValid) //what is validation? (Add to viewmodel)
      {
        var p = new PizzaFactory(); //use dependency injection instead of new

        //p.Create(pizzaViewModel);
        //repository.Create(pizzaViewModel);
        //return View("User");
        return Redirect("/user/index"); // http 300-series status
        //return Redirect
      }

      return View("Order", pizzaViewModel);
    }

    // http status
    /*
    - 100-series = network
    - 200-series = all is good, 200-ok, 201-modified, 202-notmodified
    - 300-series = redirection, temporary, permanent
    - 400-series = user is stupid, client error
    - 500-series = dev is stupid, server error
    */
  }
}