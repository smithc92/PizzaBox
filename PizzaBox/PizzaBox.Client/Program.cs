using System;
using PizzaBox.Domain.Recipes;
using PizzaBox.Domain.Models;
using System.Collections.Generic;

namespace PizzaBox.Client
{
  class Program
  {
    static void Main(string[] args)
    {
      Location Dallas = new Location();
      Location Arlington = new Location();
      Location Plano = new Location();
      string cityName1 = "Dallas";
      string cityName2 = "Arlington";
      string cityName3 = "Plano";
      Address a1 = new Address();
      Address a2 = new Address();
      Address a3 = new Address();
      a1.City = cityName1;
      a2.City = cityName2;
      a3.City = cityName3;
      Dallas.Address = a1;
      Arlington.Address = a2;
      Plano.Address = a3;
      List<Order> OrderList1 = new List<Order>();
      List<Order> OrderList2 = new List<Order>();
      List<Order> OrderList3 = new List<Order>();
      Dallas.Orders = OrderList1;
      Arlington.Orders = OrderList2;
      Plano.Orders = OrderList3;

      Console.WriteLine("Welcome to PizzaBox!");
      int i = 1;
      int j = 1;
      string FirstName = "{placeholder first name}";
      string LastName = "{placeholder last name}";
      int StoreNum = 0;
      bool Signin = false;
      
      while(j != 0 && Signin != true)
      {
        Console.WriteLine("Make a selection: ");
        Console.WriteLine("1. Register Now!");
        Console.WriteLine("2. Sign-In!");
        Console.WriteLine("0. Exit");
        j = Convert.ToInt32(Console.ReadLine());
        switch(j)
        {
          case 0:
              Console.WriteLine("Thank-You for your service! Good-Bye!");
              break;
          case 1:
            Console.WriteLine("First Name: ");
            FirstName = Console.ReadLine();
            Console.WriteLine("Last Name: ");
            LastName = Console.ReadLine();
            Signin = true;
            break;
          case 2:
            Console.WriteLine("Please enter the  first name for the order: ");
            FirstName = Console.ReadLine();
            Console.WriteLine("Please enter the  last name for the order: ");
            LastName = Console.ReadLine();
            Signin = true;
            //pull from existing users
            break;
          default:
            Console.WriteLine("Please enter a valid selection to continue...");
            break;
        }
      }
      Name userName = new Name();
      userName.First = FirstName;
      userName.Last = LastName;
      User u = AccountCreation(userName);
      Order O = new Order();
      List<CustomPizza> CP = new List<CustomPizza>();
      O.PizzaOrder = CP;
      while(i != 0 && Signin != false && i != 12345)
      {
        Console.WriteLine("Welcome Back, " + FirstName + " " + LastName);
        Console.WriteLine("Make a selection: ");
        Console.WriteLine("1. View Our Locations!");
        Console.WriteLine("2. Select a Location!");
        Console.WriteLine("3. Make an Order!");
        Console.WriteLine("4. Sign-Out!");
        Console.WriteLine("5. View Order!");
        Console.WriteLine("0. Exit");
        i = Convert.ToInt32(Console.ReadLine());
      
        switch(i)
        {
          case 0:
            Console.WriteLine("Thank-You for your service! Good-Bye!");
            break;
          case 1:
            Console.WriteLine("Available Locations are: ");
            Console.WriteLine("Dallas, Arlington, Plano");
            break;
          case 2: 
            while(StoreNum != 1 && StoreNum != 2 && StoreNum != 3)
            {
              Console.WriteLine("Select a store from the options below: ");
              Console.WriteLine("1. Dallas 2. Arlington 3. Plano");
              StoreNum = Convert.ToInt32(Console.ReadLine());
            }
            break;
          case 3:
            if(StoreNum == 0)
            {
              Console.WriteLine("Select a store first to continue!");
            }
            else
            {
              int k = 0;
              while(k == 0 && k != 1 && k != 2 && k != 3)
              {
                Console.WriteLine("Choose Pizza: 1. Custom 2. Chicago 3. New York");
                k = Convert.ToInt32(Console.ReadLine());
                if(k==1)
                {
                  List<Topping> ToppingList = new List<Topping>();
                  CustomPizza p = new CustomPizza();
                  p.Toppings = ToppingList;
                  MakePizza(u, p);
                  O.PizzaOrder.Add(p);
                  Console.WriteLine(p);
                }
                if(k==2)
                {
                  MakeChicagoPizza();
                }
                if(k==3)
                {
                  MakeNewYorkPizza();
                } 
              }  
            }
            break;
          case 4:
            Console.WriteLine("Signing you out...");
            Signin = false;
            break;
          case 5:
            Console.WriteLine(O.PrintOrder());
            break;
          default:
            Console.WriteLine("Please enter a valid selection to continue...");
            break;
        }
        if(StoreNum==1)
        {
          Dallas.Orders.Add(O);
        }
        if(StoreNum==2)
        {
          Arlington.Orders.Add(O);
        }
        if(StoreNum==3)
        {
          Plano.Orders.Add(O);
        }
      }
      if(i == 12345)
      {
        int k = 9;
        while(k != 0)
        {
          Console.WriteLine("Choose an Option: 1. View full order list by location. 2. View Order Count 0. Exit");
          k = Convert.ToInt32(Console.ReadLine());
          switch(k)
          {
            case(0):
              Console.WriteLine("Thank-You for using our application. Good-Bye.");
              break;
            case(1):
                if(StoreNum==1)
                {
                  Console.WriteLine(Dallas.PrintLocationOrders());
                }
                if(StoreNum==2)
                {
                  Arlington.PrintLocationOrders();
                }
                if(StoreNum==3)
                {
                  Plano.PrintLocationOrders();
                }
                break;
              case(2):
                if(StoreNum==1)
                {
                  Console.WriteLine(Dallas);
                }
                if(StoreNum==2)
                {
                  Console.WriteLine(Arlington);
                }
                if(StoreNum==3)
                {
                  Console.WriteLine(Plano);
                }
                break;
            default:
              Console.WriteLine("Please enter a valid selection to continue...");
              break;
          }
        }
      }
    }

    static void MakeNewYorkPizza()
    {
      var ny1 = new NewYork();
      var ny2 = new NewYork();
    }

    static void MakeChicagoPizza()
    {
      var deepdish = new Chicago();

      var chi1 = deepdish.Make();
      var chi2 = deepdish.Make();
    }
    static CustomPizza MakePizza(User u, CustomPizza p1)
    {
      Console.WriteLine(
        "What type of crust would you like? (stuffed,pan,hand)");
      Crust c = new Crust(Console.ReadLine());
      p1.Crust = c;
      Console.WriteLine("What size? (small/medium/large)");
      Size s = new Size(Console.ReadLine());
      p1.Size = s; 
      Topping[] toppings = new Topping[4];
      for(int i = 0; i < 4; ++i)
      {
        Console.WriteLine("What are you toppings? (2 min, 5 max)");
        string test = Console.ReadLine();
        if(test == "")
        {
          i = 5;
        }
        else
        {
          toppings[i] = new Topping(test);
          p1.Toppings.Add(toppings[i]);
        }  
      }
      p1.ToppingCount = p1.Toppings.Count;
      return p1;
    }
    public static User AccountCreation(Name N)
    {
      User u1 = new User();
      u1.Name = N;
      return u1;
    }
}
}
