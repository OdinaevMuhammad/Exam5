using Domain.Dtos;
using Dapper;
using Npgsql;
public class CategoryService
{
    private string  _connectionString = "Server=127.0.0.1;Port=5432;Database=Exam2;User Id=postgres;Password=2005;";

   public List<Category> GetInfoCategory()
    {
        using (var conn = new NpgsqlConnection(_connectionString))
        {
            var sql = "Select * from Category";
            
            return conn.Query<Category>(sql).ToList();
        }
    }
       public int InsertCategory(Category  Category)
        {
            using (var conn = new NpgsqlConnection(_connectionString))
            {
                var sql =
                    $"insert into Category (CategoryName) VALUES " +
                    $"('{Category.CategoryName}')"; 

                var result = conn.Execute(sql);

                return result;
            }
        }

         public int UpdateCategory(Category Category)
        {
            using (var conn = new NpgsqlConnection(_connectionString))
            {
                var sql = 
                    $"UPDATE Category SET " +
                    $"id = {Category.id}, " +
                    $"Categoryname = '{Category.CategoryName}'" +
                    $"WHERE id = {Category.id}";

                var result = conn.Execute(sql);

                return result;
            }
        }

          public int DeleteCategory(int id)
        {
            using (var conn = new NpgsqlConnection(_connectionString))
            {
                var sql = $"DELETE FROM Category WHERE id = {id}";

                var result = conn.Execute(sql);

                return result;
            }
        }
        
}