using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KonyvtarNyilvantartas.Data;
using KonyvtarNyilvantartas.Models;
using AutoMapper;
using KonyvtarNyilvantartas.DTOs;

namespace KonyvtarNyilvantartas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly LibraryDbContext _context;
        private readonly IMapper _mapper;

        public AuthorsController(LibraryDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AuthorReadDTO>>> GetAuthors()
        {
            var authors = await _context.Authors.ToListAsync();
            var authorsDto = _mapper.Map<List<AuthorReadDTO>>(authors);

            return Ok(authorsDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AuthorReadDTO>> GetAuthor(int id)
        {
            var author = await _context.Authors.FindAsync(id);

            if (author == null) return NotFound();

            var authorDto = _mapper.Map<AuthorReadDTO>(author);

            return Ok(authorDto);
        }

        [HttpPost]
        public async Task<ActionResult<Author>> PostAuthor(AuthorCreateDTO authorDto)
        {
            var author = _mapper.Map<Author>(authorDto);

            _context.Authors.Add(author);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAuthor", new { id = author.Id }, author);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAuthor(int id, AuthorCreateDTO authorDto)
        {
            var author = await _context.Authors.FindAsync(id);

            if (author == null)
            {
                return NotFound();
            }

            _mapper.Map(authorDto, author);
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
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthor(int id)
        {
            var author = await _context.Authors.FindAsync(id);
            if (author == null)
            {
                return NotFound();
            }

            _context.Authors.Remove(author);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AuthorExists(int id)
        {
            return _context.Authors.Any(e => e.Id == id);
        }
    }
}
