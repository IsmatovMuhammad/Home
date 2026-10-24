using System.Xml.Serialization;
using Domain.Models;
using Infrastructure.Data;
using Npgsql;

namespace Infrastructure.Repository;

public class CategoryRepository : ICategoryRepository
{
    public void AddCategory(Category category)
    {
        using var conn = DataBase.Connection();
        conn.Open();
        var query = "insert into categories(name)values(@name)";
        var cmd = new NpgsqlCommand(query, conn);
        cmd.Parameters.AddWithValue("name", category.Name);
        var result = cmd.ExecuteNonQuery();
        if(result>0)System.Console.WriteLine("Category added!!");
    }

    public void DeleteCategory(int id)
    {
        using var conn = DataBase.Connection();
        conn.Open();
        var query = "delete from categories where id = @id";
        var cmd = new NpgsqlCommand(query, conn);
        cmd.Parameters.AddWithValue("id", id);
        var result = cmd.ExecuteNonQuery();
        if(result > 0) System.Console.WriteLine("Category deleted");
    }

    public List<Category> GetCategories()
    {
        using var conn = DataBase.Connection();
        conn.Open();
        var query = "select * from categories";
        var cmd = new NpgsqlCommand(query, conn);
        var data = cmd.ExecuteReader();
        List<Category> categories = new();
        while (data.Read())
        {
            Category category = new();
            category.Id = data.GetInt32(0);
            category.Name = data.GetString(1);
            categories.Add(category);
        }
        return categories;
    }

    public Category GetCategory(int id)
    {
        using var conn = DataBase.Connection();
        conn.Open();
        var query = "Select * from categories where id = @id";
        var cmd = new NpgsqlCommand(query, conn);
        cmd.Parameters.AddWithValue("id", id);
        var data = cmd.ExecuteReader();
        Category category = new();
        while (data.Read())
        {
            category.Id = data.GetInt32(0);
            category.Name = data.GetString(1);
        }
        return category;
    }

    public void UpdateCategory(Category category)
    {
        using var conn = DataBase.Connection();
        conn.Open();
        var query = "update categories set name = @name where id = @id";
        var cmd = new NpgsqlCommand(query, conn);
        cmd.Parameters.AddWithValue("name", category.Name);
        cmd.Parameters.AddWithValue("id", category.Id);
        cmd.ExecuteNonQuery();
        System.Console.WriteLine("Category update!");
    }

}
