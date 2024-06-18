using AutoMapper;
using Fierolla_Api.Data;
using Fierolla_Api.DTOs.Sliders;
using Fierolla_Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace Fierolla_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SliderController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public SliderController(AppDbContext context,
                                 IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            return Ok(_mapper.Map<List<SliderDTo>>(await _context.Sliders.AsNoTracking().ToListAsync()));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] SliderCreateDTo request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            await _context.Sliders.AddAsync(_mapper.Map<Slider>(request));
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Create), request);

        }

        [HttpPut]
        public async Task<IActionResult> Edit(int id, [FromForm] SliderEditDTo request)
        {
            var entity = await _context.Sliders.AsNoTracking().FirstOrDefaultAsync(m => m.Id == id);

            if (entity == null) return NotFound();

            _mapper.Map(request, entity);

            _context.Sliders.Update(entity);

            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] int? id)
        {
            if (id == null) return BadRequest();

            var entity = await _context.Sliders.AsNoTracking().FirstOrDefaultAsync(m => m.Id == id);

            if (entity == null) return NotFound();

            _context.Remove(entity);

            await _context.SaveChangesAsync();

            return Ok();
        }




    }
}
