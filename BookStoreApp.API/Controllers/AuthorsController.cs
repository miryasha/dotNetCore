using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookStoreApp.API.Data;
using Microsoft.Data.SqlClient;
using BookStoreApp.API.Models.Author;
using AutoMapper;

namespace BookStoreApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper mapper;

        public AuthorsController(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            this.mapper = mapper;   
        }

        // GET: api/Authors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AuthorReadOnlyDto>>> GetAuthors()
        {
            //if (_context.Authors == null)
            //{
            //    return NotFound();
            //}
            //return await _context.Authors.ToListAsync();
            var authors = await _context.Authors.ToListAsync();
            var authorsDtos = mapper.Map<IEnumerable<AuthorReadOnlyDto>>(authors);
            return Ok(authorsDtos);
        }

        // GET: api/Authors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AuthorReadOnlyDto>> GetAuthor(int id)
        {
          if (_context.Authors == null)
          {
              return NotFound();
          }
            var author = await _context.Authors.FindAsync(id);

            if (author == null)
            {
                return NotFound();
            }

            var authorsDtos = mapper.Map<IEnumerable<AuthorReadOnlyDto>>(author);

            return Ok(authorsDtos);
        }


        // GET: api/Authors/firstName
        //[HttpGet("{FirstName}")]
        //public async Task<ActionResult<AuthorCreateDto>> GetByFirstName(AuthorCreateDto FirstName)
        //{
        //    //if (_context.Authors == null)
        //    //{
        //    //    return NotFound();
        //    //}
        //    var firstName = mapper.Map<Author>(FirstName);
        //    var author = await _context.Authors
        //        .FromSqlRaw($"Select * FROM [BookStoreDb].[dbo].[Authors] WHERE FirstName =  {firstName};").ToListAsync();
        //    Console.WriteLine(author);
        //    if (author == null)
        //    {
        //        return NotFound();
        //    }

        //    return author;
        //}

        // PUT: api/Authors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAuthor(int id, AuthorUpdateDto authorDto)
        {
            if (id != authorDto.Id)
            {
                // logger.LogWarning($"Update ID invalid in {nameof(PutAuthor)} - ID: {id}");
                return BadRequest();
            }

            var author = await _context.Authors.FindAsync(id);

            if (author == null)
            {
                //logger.LogWarning($"{nameof(Author)} record not found in {nameof(PutAuthor)} - ID: {id}");
                return NotFound();
            }

            mapper.Map(authorDto, author);
            _context.Entry(author).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AuthorExists(id))
                {
                    return NotFound();
                }
                else
                {
                    // logger.LogError(ex, $"Error Performing GET in {nameof(PutAuthor)}");
                    //return StatusCode(500, Messages.Error500Message);
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Authors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AuthorCreateDto>> PostAuthor(AuthorCreateDto authorDto)
        {
            //if (_context.Authors == null)
            //{
            //    return Problem("Entity set 'BookStoreDbContext.Authors'  is null.");
            //}
            //var author = new Author
            //{
            //    FirstName = authorDto.FirstName,
            //    LastName = authorDto.LastName,
            //    Bio = authorDto.Bio
            //};
            var author = mapper.Map<Author>(authorDto);
            _context.Authors.Add(author);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAuthor", new { id = author.Id }, author);
        }

        // DELETE: api/Authors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthor(int id)
        {
            try
            {
                var author = await _context.Authors.FindAsync(id);
                if (author == null)
                {
                    //logger.LogWarning($"{nameof(Author)} record not found in {nameof(DeleteAuthor)} - ID: {id}");
                    return NotFound();
                }

                _context.Authors.Remove(author);
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception)
            {
                //logger.LogError(ex, $"Error Performing DELETE in {nameof(DeleteAuthor)}");
                return StatusCode(500);
            }
        }

        private bool AuthorExists(int id)
        {
            return (_context.Authors?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
