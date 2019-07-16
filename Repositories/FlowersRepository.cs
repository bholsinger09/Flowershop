using System;
using System.Collections.Generic;
using System.Data;
using Flowershop.Models;
using Dapper;

namespace Flowershop.Repositories
{
  public class FlowerRepository
  {
    private readonly IDbConnection _db;
    public FlowerRepository(IDbConnection db)
    {
      _db = db;
    }
    public IEnumerable<Flower> GetAll()
    {
      return _db.Query<Flower>("SELECT * FROM flowers");
    }

    public Flower GetById(int id)
    {
      string query = "SELECT * FROM sides WHERE id = @id";
      Flower data = _db.QueryFirstOrDefault<Flower>(query, new { id });
      if (data == null) throw new Exception("Invalid Id"); //throw creates a new exception
      return data;
    }

    public Flower Create(Flower value)
    {
      string query = @"INSERT INTO sides (name, description) VALUES (@Name, @Description, @Price); 
                            SELECT LAST_INSERT_ID();";
      int id = _db.ExecuteScalar<int>(query, value);
      value.Id = id;
      return value;
    }

    public Flower Update(Flower value)
    {
      string query = @"
                UPDATE sides
                SET
                    name = @Name,
                    description = @Description
                WHERE id = @Id;
                SELECT * FROM flowers WHERE id = @Id
            ";
      return _db.QueryFirstOrDefault<Flower>(query, value);
    }

    public string Delete(int id)
    {
      string query = "DELETE FROM flowers WHERE id = @id";
      int changedRows = _db.Execute(query, new { id });
      if (changedRows < 1) throw new Exception("Invalid Id");
      return "Sucessfully Deleted Side";
    }
  }
}