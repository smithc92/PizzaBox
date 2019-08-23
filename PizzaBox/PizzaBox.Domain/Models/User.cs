using System.Collections.Generic;

namespace PizzaBox.Domain.Models
{
  public class User
  {
    public Name Name { get; set; }
    public List<Order> Orders { get; set; }
    public Location Recent { get; set; }
  }
}