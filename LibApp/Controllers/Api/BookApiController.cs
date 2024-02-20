using LibApp.Data;
using LibApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace LibApp.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public BooksApiController(ApplicationDbContext context)
        {
            _context = context;
        }

        
        [HttpGet]
        public ActionResult<IEnumerable<Book>> GetBooks()
        {
            return _context.Books.ToList();
        }

       
        [HttpGet("{id}")]
        public ActionResult<Book> GetBook(int id)
        {
            var book = _context.Books.Find(id);

            if (book == null)
            {
                return NotFound();
            }

            return book;
        }
    }
}
