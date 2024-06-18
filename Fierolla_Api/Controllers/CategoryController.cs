using AutoMapper;
using Fierolla_Api.Data;
using Fierolla_Api.DTOs.Ctegories;
using Fierolla_Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace Fierolla_Api.Controllers
{
    public class CategoryController : BaseController
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public CategoryController(AppDbContext context,
                                  IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(_mapper.Map<List<CategoryDTo>>(await _context.Categories.AsNoTracking().ToListAsync()));

        }


        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CategoryCreateDTo request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            await _context.Categories.AddAsync(_mapper.Map<Category>(request));
           // await _context.Categories.AddAsync(new Category { Name = request.Name });

            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Create), request);

        }



        [HttpPut]
        public async Task<IActionResult> Edit(int id, [FromForm] CategoryEditDto request)
        {
            var entity = await _context.Categories.AsNoTracking().FirstOrDefaultAsync(m => m.Id == id);

            if (entity == null) return NotFound();

            _mapper.Map(request, entity);

            _context.Categories.Update(entity);

            await _context.SaveChangesAsync();

            return Ok();
        }



        [HttpGet("{id}")]

        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var entity = await _context.Categories.AsNoTracking().FirstOrDefaultAsync(m => m.Id == id);

            if (entity == null) return NotFound();

            return Ok(_mapper.Map<CategoryDTo>(entity));


        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] int? id)
        {
            if (id == null) return BadRequest();

            var entity = await _context.Categories.AsNoTracking().FirstOrDefaultAsync(m => m.Id == id);

            if (entity == null) return NotFound();

            _context.Remove(entity);

            await _context.SaveChangesAsync();

            return Ok();
        }



    }
}
