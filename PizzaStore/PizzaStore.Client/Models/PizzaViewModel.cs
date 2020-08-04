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
        new CrustModel(){Name = "thin"},
        new CrustModel(){Name = "stuffed"}
      };
      Sizes = new List<SizeModel>
      {
        new SizeModel(){Name = "small"},
        new SizeModel(){Name = "large"}
      };
      Toppings = new List<ToppingModel>
      {
        new ToppingModel(){Name = "pepperoni"},
        new ToppingModel(){Name = "sausage"}
      };
    }

    //Used for storing
    [Required(ErrorMessage = "Better select Crust")]
    public string Crust { get; set; }
    [Required]
    public string Size { get; set; }
    [Range(2,5)]
    public List<string> SelectedToppings { get; set; }
    public bool SelectedTopping { get; set; }
  }
}
