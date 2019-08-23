using System;
using Xunit;
using PizzaBox.Domain.Models;
using System.Collections.Generic;

namespace PizzaBox.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
          //arrange
          CustomPizza p1 = new CustomPizza();
          p1.Crust = new Crust("stuffed");
          p1.Size = new Size("large");
          Topping[] toppings = new Topping[4];
          toppings[0] = new Topping("pepperoni");
          toppings[1] = new Topping("hamburger");
          toppings[2] = new Topping("porkchop");
          toppings[3] = new Topping("bacon");
          List<Topping> t1 = new List<Topping>();
          t1.AddRange(toppings);
          p1.Toppings = t1;
          p1.ToppingCount = toppings.Length;
          var expectedCrust = "stuffed";
          var expectedSize = "large";
          var expectedToppingCount = 4;
          var expectedPrice = 9;
          //act
          var actualCrust = p1.Crust.Name;
          var actualSize = p1.Size.Name;
          var actualToppingCount = p1.ToppingCount;
          var actualPrice = p1.Price();
          //assert
          Assert.True(
            expectedCrust == actualCrust && expectedSize == actualSize && 
            expectedToppingCount == actualToppingCount && expectedPrice == actualPrice);
        }
    }
}
