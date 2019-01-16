using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using BurgerShack.Models;

namespace Burgershack.Repositories
{
  public class BurgerRepository
  {
    private readonly IDbConnection _db;

    public BurgerRepository(IDbConnection db)
    {
      _db = db;
    }
    public IEnumerable<Burger> GetAll()
    {
      return _db.Query<Burger>("SELECT * FROM Burgers");
    }

    public Burger GetBurgerById(int id)
    {
      return _db.QueryFirstOrDefault<Burger>($"SELECT * FROM Burgers WHERE id = @id", new { id });
    }

    public Burger AddBurger(Burger newburger)
    {
      int id = _db.ExecuteScalar<int>(@"
 	  INSERT INTO burgers(Name, Description, Price) Values(@Name, @Description, @Price);
 	  SELECT LAST_INSERT_ID();", newburger);
      newburger.Id = id;
      return newburger;
    }

    public Burger EditBurger(int id, Burger newburger)
    {
      try
      {
        return _db.QueryFirstOrDefault<Burger>($@"
          UPDATE burgers SET
          Name= @Name,
          Description = @Description,
          Price = @Price
          WHERE Id = @Id;
          SELECT * FROM burgers WHERE id = @Id;
        ", newburger);
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex);
        return null;
      }
    }



    public bool DeleteBurger(int id)
    {
      int success = _db.Execute("DELETE FROM Burgers WHERE id = @id", new { id });
      if (success == 0)
      {
        return false;
      }
      return true;
    }







    public BurgerRepository()
    {

    }
  }
}