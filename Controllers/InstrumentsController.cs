using Microsoft.AspNetCore.Mvc;
using InstrumentRentalApi.Models;
using InstrumentRentalApi.Services;
namespace InstrumentRentalApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InstrumentsController : ControllerBase
    {
        private readonly IInstrumentService _instrumentService;

        public InstrumentsController(IInstrumentService instrumentService)
        {
            _instrumentService = instrumentService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Instrument>>> GetAll()
        {
            return Ok(await _instrumentService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Instrument>> GetById(string id)
        {
            var instrument = await _instrumentService.GetByIdAsync(id);
            if (instrument == null) return NotFound();
            return Ok(instrument);
        }

        [HttpPost]
        public async Task<ActionResult<Instrument>> Create(Instrument instrument)
        {
            var created = await _instrumentService.CreateAsync(instrument);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, Instrument instrument)
        {
            var result = await _instrumentService.UpdateAsync(id, instrument);
            if (!result) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var result = await _instrumentService.DeleteAsync(id);
            if (!result) return NotFound();
            return NoContent();
        }
    }
}