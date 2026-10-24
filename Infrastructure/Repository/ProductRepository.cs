using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Data;
using Npgsql;

namespace Infrastructure.Repository;

public class ProductRepository : IProductsRepository
{
    public void AddProduct(Product product)
    {
        using var conn = DataBase.Connection();
        conn.Open();
        var query = "insert into products(name, price, categoryid)values(@name, @price, @categoryid)";
        var cmd = new NpgsqlCommand(query, conn);
        cmd.Parameters.AddWithValue("name", product.Name);
        cmd.Parameters.AddWithValue("price", product.Price);
        cmd.Parameters.AddWithValue("categoryid", product.CategoryId);
        var result = cmd.ExecuteNonQuery();
        if(result > 0) System.Console.WriteLine("Product added!!");
        else System.Console.WriteLine("Error !!");
    }

    public void DeleteProduct(int id)
    {
        using var conn = DataBase.Connection();
        conn.Open();
        var query = "delete from products where id = @id";
        var cmd = new NpgsqlCommand(query, conn);
        cmd.Parameters.AddWithValue("id", id);
        var result = cmd.ExecuteNonQuery();
        if(result > 0) System.Console.WriteLine("Product deleted!!");
        else System.Console.WriteLine("Error !!");
    }

    public Product GetProduct(int id)
    {
        using var conn = DataBase.Connection();
        conn.Open();
        var query = "Select * from products where id = @id";
        var cmd = new NpgsqlCommand(query, conn);
        cmd.Parameters.AddWithValue("id", id);
        var data = cmd.ExecuteReader();
        if(!data.Read()) System.Console.WriteLine("Not fiend");
        Product product = new();
        while (data.Read())
        {
            product.Id = data.GetInt32(0);
            product.Name = data.GetString(1);
            product.Price = data.GetDecimal(2);
        }
        return product;
    }

    public List<Product> GetProductByCategory(string name)
    {
        using var conn = DataBase.Connection();
        conn.Open();
        var query = "Select p.* from products p join categories c on c.id = p.categoryid where c.name = @name";
        var cmd = new NpgsqlCommand(query, conn);
        cmd.Parameters.AddWithValue("name", name);
        var data = cmd.ExecuteReader();
        if(!data.Read()) System.Console.WriteLine("Not fiend");
        List<Product> products = new();
        while (data.Read())
        {
            Product product = new();
            product.Id = data.GetInt32(0);
            product.Name = data.GetString(1);
            product.Price = data.GetDecimal(2);
            product.CategoryId = data.GetInt32(3);
            products.Add(product);
        }
        return products;
    }


    public List<Product> GetProducts()
    {
        using var conn = DataBase.Connection();
        conn.Open();
        var query = "select * from products";
        var cmd = new NpgsqlCommand(query, conn);
        var data = cmd.ExecuteReader();
        if(!data.Read()) System.Console.WriteLine("Not fiend");
        List<Product> products = new();
        while (data.Read())
        {
            Product product = new();
            product.Id = data.GetInt32(0);
            product.Name = data.GetString(1);
            product.Price = data.GetDecimal(2);
            products.Add(product);
        }
        return products;

    }

    public void UpdateProduct(Product product)
    {
        using var conn = DataBase.Connection();
        conn.Open();
        var query = "update products set name = @name, price = @price where id = @id";
        var cmd = new NpgsqlCommand(query, conn);
        cmd.Parameters.AddWithValue("name", product.Name);
        cmd.Parameters.AddWithValue("price", product.Price);
        var result = cmd.ExecuteNonQuery();
        if(result > 0) System.Console.WriteLine("Product Updated!!");
    }

}
