using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
  public class Order
  {
    public List<APizza> Pizzas { get; set; }
    public decimal Price { get; set; }
    public List<CustomPizza> PizzaOrder { get; set; }

    public override string ToString()
    {
      return "This order contains " + PizzaOrder.Count+ " pizzas.";
    }

    public double OrderCost()
    {
      double OrderCost = 0;
      foreach (var CustomPizza in PizzaOrder)
      {
        OrderCost += CustomPizza.Price();
      }
      return OrderCost;
    }
    public string PrintOrder()
    {
      string order = "This order contains: ";
      foreach (var CustomPizza in PizzaOrder)
      {
        order += CustomPizza.ToString() + " ";
      }
      order += "Grand Total: $" + OrderCost(); 
      return order;
    }
}
}
