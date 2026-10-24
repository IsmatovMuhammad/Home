using Domain.Models;
using Infrastructure.Repository;

var categoryRepo = new CategoryRepository();
var productRepo = new ProductRepository();

while (true)
{
    System.Console.WriteLine("===============================");
    System.Console.WriteLine(@"    Category
1 - Show all categories.
2 - Show category.
3 - Add new category.
4 - Update category.
5 - Delete category.

    Product
6 - Show all products
7 - Show product by id
8 - Show product by category name
9 - Add new products
10 - Delete products
11 - Update products
0 - Exit.");
    var a = Console.ReadLine();
    System.Console.WriteLine("===============================");
    switch (a)
    {
        case "1":
            var allCategories = categoryRepo.GetCategories();
            foreach(var item in allCategories)
            {
                System.Console.WriteLine(item.Id+" "+item.Name);
            }
            break;
        case "2":
            System.Console.Write("Enter id of category: ");
            var categoryIdToShow = Convert.ToInt32(Console.ReadLine());
            var categoryToShow = categoryRepo.GetCategory(categoryIdToShow);
            System.Console.WriteLine(categoryToShow.Id+" "+categoryToShow.Name);
            break;
        case "3":
            System.Console.Write("Enter name: ");
            var categoryName = Console.ReadLine()!;
            var newCategory = new Category()
            {
                Name = categoryName
            };
            categoryRepo.AddCategory(newCategory);
            break;
        case "4":
            System.Console.Write("Enter id: ");
            var categoryIdToUpdate = Convert.ToInt32(Console.ReadLine());
            System.Console.Write("Enter new name: ");
            var newCategoryName = Console.ReadLine()!;
            var categoryToUpdate = new Category()
            {
                Id = categoryIdToUpdate,
                Name = newCategoryName
            };
            categoryRepo.UpdateCategory(categoryToUpdate);
            break;
        case "5":
            System.Console.Write("Enter id: ");
            var categoryIdToDelete = Convert.ToInt32(Console.ReadLine());
            categoryRepo.DeleteCategory(categoryIdToDelete);
            break;
        case "6":
            var allproduct = productRepo.GetProducts();
            foreach (var it in allproduct)
            {
                System.Console.WriteLine(it.Id+" | "+it.Name+" | "+it.Price+" | "+it.CategoryId);
            }
            break;
        case "7":
            Console.Write("Enter id: ");
            int id7 = Convert.ToInt32(Console.ReadLine());
            var pct7 = productRepo.GetProduct(id7);
            System.Console.WriteLine(pct7.Id+" | "+pct7.Name+" | "+pct7.Price+" | "+pct7.CategoryId);
            break;
        case "8":
            System.Console.Write("Enter category name: ");
            string name8 = Console.ReadLine()!;
            var allcategory = productRepo.GetProductByCategory(name8);
            foreach (var it8 in allcategory)
            {
                Console.WriteLine(it8.Id+" | "+it8.Name+" | "+it8.Price+" | "+it8.CategoryId);
            }
            break;
        case "9":
            System.Console.Write("Name: ");
            string name = Console.ReadLine()!;
            System.Console.Write("Price: ");
            decimal price = Convert.ToDecimal(Console.ReadLine());
            System.Console.Write("CategoryId: ");
            int catId = Convert.ToInt32(Console.ReadLine());
            Product product = new()
            {
                Name = name,
                Price = price,
                CategoryId = catId
            };
            productRepo.AddProduct(product);
            break;
        case "10":
            System.Console.WriteLine("Enter id: ");
            int id = Convert.ToInt32(Console.ReadLine());
            productRepo.DeleteProduct(id);
            break;
        case "11":
            System.Console.Write("Name: ");
            string name1 = Console.ReadLine()!;
            System.Console.Write("Price: ");
            decimal price1 = Convert.ToDecimal(Console.ReadLine());
            System.Console.Write("CategoryId: ");
            int catId1 = Convert.ToInt32(Console.ReadLine());
            Product product1 = new()
            {
                Name = name1,
                Price = price1,
                CategoryId = catId1
            };
            productRepo.AddProduct(product1);
            break;
        case "0":
            System.Console.WriteLine("Exiting ...");
            return;
    }
}
