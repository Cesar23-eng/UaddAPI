using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UaddAPI.Data;
using UaddAPI.Dto.Event;
using UaddAPI.Models;

namespace UaddAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventsController : ControllerBase
    {
        private readonly UaddDbContext _context;

        public EventsController(UaddDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventDto>>> GetAll()
        {
            var events = await _context.Events
                .Select(e => new EventDto
                {
                    Id = e.Id,
                    Title = e.Title,
                    Date = e.Date,
                    Location = e.Location,
                    ImageUrl = e.ImageUrl
                })
                .ToListAsync();

            return Ok(events);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EventDetailDto>> Get(int id)
        {
            var ev = await _context.Events.FirstOrDefaultAsync(e => e.Id == id);
            if (ev == null) return NotFound();

            var dto = new EventDetailDto
            {
                Id = ev.Id,
                Title = ev.Title,
                Description = ev.Description,
                Date = ev.Date,
                Location = ev.Location,
                ImageUrl = ev.ImageUrl,
                CreatedByUserId = ev.CreatedByUserId
            };

            return Ok(dto);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<EventDto>> Create(EventCreateDto dto)
        {
            var userId = int.Parse(User.Identity!.Name!);

            var ev = new Event
            {
                Title = dto.Title,
                Description = dto.Description,
                Date = dto.Date,
                Location = dto.Location,
                ImageUrl = dto.ImageUrl,
                CreatedByUserId = userId
            };

            _context.Events.Add(ev);
            await _context.SaveChangesAsync();

            var result = new EventDto
            {
                Id = ev.Id,
                Title = ev.Title,
                Date = ev.Date,
                Location = ev.Location,
                ImageUrl = ev.ImageUrl
            };

            return CreatedAtAction(nameof(Get), new { id = ev.Id }, result);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(int id, EventCreateDto dto)
        {
            var ev = await _context.Events.FirstOrDefaultAsync(e => e.Id == id);
            if (ev == null) return NotFound();

            ev.Title = dto.Title;
            ev.Description = dto.Description;
            ev.Date = dto.Date;
            ev.Location = dto.Location;
            ev.ImageUrl = dto.ImageUrl;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var ev = await _context.Events.FirstOrDefaultAsync(e => e.Id == id);
            if (ev == null) return NotFound();

            _context.Events.Remove(ev);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
