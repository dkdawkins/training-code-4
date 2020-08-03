using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using PizzaStore.Domain.Factories;
using PizzaStore.Domain.Models;

namespace PizzaStore.Client.Models
{
  public class PizzaViewModel
  {
    //Used for display
    public List<CrustModel> Crusts { get; set; }
    public List<SizeModel> Sizes { get; set; }
    public List<ToppingModel> Toppings { get; set; }

    public PizzaViewModel() //ONLY USE THIS FOR TESTING!!!
    {
      Crusts = new List<CrustModel>
      {
        new CrustModel(){Id = 1, Name = "thin"},
        new CrustModel(){Id = 2, Name = "stuffed"}
      };
      Sizes = new List<SizeModel>
      {
        new SizeModel(){Id = 1, Name = "small"},
        new SizeModel(){Id = 2, Name = "large"}
      };
      Toppings = new List<ToppingModel>
      {
        new ToppingModel(){Id = 1, Name = "pepperoni"},
        new ToppingModel(){Id = 2, Name = "sausage"}
      };
    }

    //Used for storing
    [Required]
    public CrustModel Crust { get; set; }
    [Required]
    public SizeModel Size { get; set; }
    [Range(2,5)]
    public List<ToppingModel> SelectedToppings { get; set; }
    public bool SelectedTopping { get; set; }
  }
}
