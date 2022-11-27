using Domain.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class QuotesController
    {
        private QuoteService _QuotesService;

        public QuotesController()
        {
            _QuotesService = new QuoteService();
        }


        [HttpGet("GetInfo")]
        public List<Quotes> GetQuotes()
        {
            return _QuotesService.GetInfoQuotes();
        }
          [HttpGet("GetRandom")]
        public List<Quotes> GetRandom()
        {
            return _QuotesService.GetRandomQuotes();
        }

        [HttpPost("Insert")]
        public int InsertQuotes(Quotes Quotes)
        {
            return _QuotesService.InsertQuotes(Quotes);
        }

        [HttpPut("Update")]
        public int UpdateQuotes(Quotes Quotes)
        {
            return _QuotesService.UpdateQuotes(Quotes);
        }

        [HttpDelete("Delete")]
        public int DeleteQuotes(int id)
        {
            return _QuotesService.DeleteQuotes(id);
        }         
                  [HttpGet("GetById")]
        public List<Quotes> GetById(int id)
        {
            return _QuotesService.GetQuotesByCategory(id);
        }    
        
    }

}
