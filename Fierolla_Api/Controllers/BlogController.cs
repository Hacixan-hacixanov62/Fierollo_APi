using AutoMapper;
using Fierolla_Api.Data;
using Fierolla_Api.DTOs.Blogs;
using Fierolla_Api.DTOs.Products;
using Fierolla_Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Fierolla_Api.Controllers
{
    public class BlogController : BaseController
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public BlogController(AppDbContext context,
                              IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(_mapper.Map<List<BlogDTo>>(await _context.Blogs.AsNoTracking().ToListAsync()));

        }


        [HttpPost]
        public async Task<IActionResult> Create([FromForm] BlogCreateDTo request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            await _context.Blogs.AddAsync(_mapper.Map<Blog>(request));
            // await _context.Categories.AddAsync(new Category { Name = request.Name });

            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Create), request);

        }



        [HttpPut]
        public async Task<IActionResult> Edit(int id, [FromBody] BlogEditDTo request)
        {
            var entity = await _context.Blogs.AsNoTracking().FirstOrDefaultAsync(m => m.Id == id);

            if (entity == null) return NotFound();

            _mapper.Map(request, entity);

            _context.Blogs.Update(entity);

            await _context.SaveChangesAsync();

            return Ok();
        }


        [HttpGet("{id}")]

        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var entity = await _context.Blogs.AsNoTracking().FirstOrDefaultAsync(m => m.Id == id);

            if (entity == null) return NotFound();

            return Ok(_mapper.Map<BlogDTo>(entity));


        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] int? id)
        {
            if (id == null) return BadRequest();

            var entity = await _context.Blogs.AsNoTracking().FirstOrDefaultAsync(m => m.Id == id);

            if (entity == null) return NotFound();

            _context.Remove(entity);

            await _context.SaveChangesAsync();

            return Ok();
        }



    }
}
