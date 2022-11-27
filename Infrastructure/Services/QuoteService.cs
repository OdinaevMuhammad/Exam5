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
                    $"insert into Quotes (Author, QuoteText,Categoryid) VALUES " +
                    $"('{Quotes.Author}', " +
                    $"'{Quotes.QuoteText}', " +
                   $"'{Quotes.Categoryid}')"; 

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
                    $"QuoteText = '{Quotes.QuoteText}', " +
                    $"Categoryid = {Quotes.Categoryid} " +
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
        public List<Quotes> GetQuotesByCategory(int id)
    {
       using (var conn = new NpgsqlConnection(_connectionString))
        {
            var sql = 
            $"Select * from quotes where categoryid = {id}";  
            
            return conn.Query<Quotes>(sql, new {id}).ToList();
        }
    }

        
}