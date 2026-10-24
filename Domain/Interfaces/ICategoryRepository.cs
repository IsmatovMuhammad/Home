namespace Domain.Models;

public interface ICategoryRepository
{
    void AddCategory(Category category);
    void DeleteCategory(int id);
    void UpdateCategory(Category category);
    Category GetCategory(int id);
    List<Category> GetCategories();
}