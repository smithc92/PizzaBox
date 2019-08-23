using System.Collections.Generic;

namespace PizzaBox.Domain.Models
{
  public class Location
  {
    public Address Address { get; set; }
    public Dictionary<string, int> Inventory { get; set; }
    public List<Order> Orders { get; set; }

    public override string ToString()
    {
      return Address.City + " has " +Orders.Count+ " orders.";
    }
    public string PrintLocationOrders()
    {
      string location = Address.City + " orders are: ";
      foreach (var Order in Orders)
      {
        location += Order.PrintOrder();
      } 
      return location;
    }
  }
}
