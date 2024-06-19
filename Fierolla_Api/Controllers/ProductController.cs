﻿using AutoMapper;
using Fierolla_Api.Data;
using Fierolla_Api.DTOs.Ctegories;
using Fierolla_Api.DTOs.Products;
using Fierolla_Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Fierolla_Api.Controllers
{
    public class ProductController : BaseController
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public ProductController(AppDbContext context,
                                  IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(_mapper.Map<List<ProductDTo>>(await _context.Products.AsNoTracking().ToListAsync()));

        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProductCreateDTo request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            await _context.Products.AddAsync(_mapper.Map<Product>(request));
            // await _context.Categories.AddAsync(new Category { Name = request.Name });

            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Create), request);

        }



        [HttpPut]
        public async Task<IActionResult> Edit(int id, [FromBody] ProductEditDTo request)
        {
            var entity = await _context.Products.AsNoTracking().FirstOrDefaultAsync(m => m.Id == id);

            if (entity == null) return NotFound();

            _mapper.Map(request, entity);

            _context.Products.Update(entity);

            await _context.SaveChangesAsync();

            return Ok();
        }


        [HttpGet("{id}")]

        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var entity = await _context.Products.AsNoTracking().FirstOrDefaultAsync(m => m.Id == id);

            if (entity == null) return NotFound();

            return Ok(_mapper.Map<ProductDTo>(entity));


        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] int? id)
        {
            if (id == null) return BadRequest();

            var entity = await _context.Products.AsNoTracking().FirstOrDefaultAsync(m => m.Id == id);

            if (entity == null) return NotFound();

            _context.Remove(entity);

            await _context.SaveChangesAsync();

            return Ok();
        }



    }
}
