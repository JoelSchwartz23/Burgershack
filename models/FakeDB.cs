using System.Collections.Generic;
using BurgerShack.Models;

namespace Burgershack.Db
{
  static class FakeDB
  {
    public static List<Burger> Burgers = new List<Burger>(){
      new Burger("Mark Burger", "A delicious burger with bacon and stuff", 7.56f),
      new Burger("Jake Burger", "Now with fries!", 8.54f),
      new Burger("D$ Burger", "It's Mostly Foraged", 6.24f)
  };
  }
}