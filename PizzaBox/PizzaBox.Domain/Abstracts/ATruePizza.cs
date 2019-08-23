using System.Collections.Generic;
using PizzaBox.Domain.Models;

namespace PizzaBox.Domain.Abstracts
{
  public abstract class ATruePizza
  {
    public Crust Crust { get; set; }
    public Size Size { get; set; }
    public List<Topping> Toppings { get; set; }
    private double CrustCost;
    private double SizeCost;
    private double ToppingMultiplier = .5;
    public double ToppingCount {get; set;}

    public double Price()
    {
      if(Crust.Name == "stuffed")
      {
        CrustCost = 2;
      }
      if(Size.Name =="large")
      {
        SizeCost = 5;
      }
      if(Size.Name =="medium")
      {
        SizeCost = 4;
      }
      if(Size.Name =="small")
      {
        SizeCost = 2;
      }
      return CrustCost + SizeCost + (ToppingMultiplier*ToppingCount);
      
    }
    

    public override string ToString()
    {
      //String t = Topping.Name;
      return "This pizza is a " + Size.Name + " " + Crust.Name + " pizza with " +
      Toppings.Count + " toppings. Total: $" + Price();
    } 


  }
}
