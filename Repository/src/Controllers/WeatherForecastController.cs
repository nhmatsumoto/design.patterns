using Microsoft.AspNetCore.Mvc;
using nhmatsumoto.repository.pattern.Context.Entities;
using nhmatsumoto.repository.pattern.Context.Interfaces;

namespace nhmatsumoto.repository.pattern.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public WeatherForecastController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public async Task<IActionResult> Get()
        {
            var repository = _unitOfWork.GetRepository<WeatherForecast>();
            var result = await repository.GetAllAsync();

            if(result.Any())
            {
                return Ok(result);
            }

            return NotFound("Nenhum registro encontrado");
        }

        [HttpPost]
        public IActionResult Post([FromBody] WeatherForecast model)
        {
            var seuModeloRepository = _unitOfWork.GetRepository<WeatherForecast>();

            seuModeloRepository.Insert(model);

            var rows = _unitOfWork.SaveChangesAsync().GetAwaiter().GetResult(); 

            if(rows > 0 && rows == 1)
            {
                return CreatedAtAction(nameof(Get), new { id = model.Id }, model);
            }

            return BadRequest("Houve um erro ao processar sua solicitação");
        }

    }
}
