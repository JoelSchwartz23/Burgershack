using System;
using System.Collections.Generic;
using Burgershack.Db;
using BurgerShack.Models;

namespace Burgershack.Repositories
{
  public class BurgerRepository
  {
    // private readonly FakeDB _db;

    // public IEnumerable<Burger> GetAll()
    // {
    //     return _db.Query<IEnumerable<Burger>>(@"
    //   //   // SELECT * FROM Burgers;
    //   //   // ")



    // }

    public Burger GetBurgerById(int id)
    {
      try
      {
        return FakeDB.Burgers[id];
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex);
        return null;
      }
    }

    public Burger AddBurger(Burger newburger)
    {
      FakeDB.Burgers.Add(newburger);
      return newburger;
    }

    public Burger EditBurger(int id, Burger newburger)
    {
      try
      {
        FakeDB.Burgers[id] = newburger;
        return newburger;
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex);
        return null;
      }
    }


    public bool DeleteBurger(int id)
    {
      try
      {
        FakeDB.Burgers.Remove(FakeDB.Burgers[id]);
        return true;
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex);
        return false;
      }
    }







    public BurgerRepository()
    {

    }
  }
}