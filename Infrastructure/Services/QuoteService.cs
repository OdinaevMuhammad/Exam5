using Domain.Dtos;
using Dapper;
using Npgsql;
public class QuoteService
{
    private string  _connectionString = "Server=127.0.0.1;Port=5432;Database=Exam2;User Id=postgres;Password=2005;";

   public List<Quotes> GetInfoQuotes()
    {
        using (var conn = new NpgsqlConnection(_connectionString))
        {
            var sql = "Select * from Quotes";
            
            return conn.Query<Quotes>(sql).ToList();
        }
    }
       public int InsertQuotes(Quotes  Quotes)
        {
            using (var conn = new NpgsqlConnection(_connectionString))
            {
                var sql =
                    $"insert into Quotes (Author, QuoteText) VALUES " +
                    $"('{Quotes.Author}', " +
                    $"'{Quotes.QuoteText}') ";
                var result = conn.Execute(sql);

                return result;
            }
        }

         public int UpdateQuotes(Quotes Quotes)
        {
            using (var conn = new NpgsqlConnection(_connectionString))
            {
                var sql = 
                    $"UPDATE Quotes SET " +
                    $"Author = '{Quotes.Author}', " +
                    $"QuoteText = '{Quotes.QuoteText}' " +
                    $"WHERE id = {Quotes.id}";

                var result = conn.Execute(sql);

                return result;
            }
        }

          public int DeleteQuotes(int id)
        {
            using (var conn = new NpgsqlConnection(_connectionString))
            {
                var sql = $"DELETE FROM Quotes WHERE id = {id}";

                var result = conn.Execute(sql);

                return result;
            }
        }
    public List<Quotes> GetRandomQuotes()
    {
        using (var conn = new NpgsqlConnection(_connectionString))
        {
            var sql = "select * from quotes order by random() limit 1";
            
            return conn.Query<Quotes>(sql).ToList();
        }
    }
        public Quotes GetById(int id)
    {
       using (var conn = new NpgsqlConnection(_connectionString))
        {
            var sql = 
            $"Select categoryname from Category where id = {id}";  
            
            return conn.QuerySingleOrDefault<Quotes>(sql, new {id});
        }
    }

        
}