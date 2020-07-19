using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;


using ByblosMiPH.API.Domain.Models;
using ByblosMiPH.API.Domain.Services;
using ByblosMiPH.API.Resources;
using ByblosMiPH.API.Extensions;
using Microsoft.Extensions.Logging;

namespace ByblosMiPH.API.Controllers
{
	//[Authorize]
	[ApiController]
	[Route("api/[controller]")]
	public class BancosController : ControllerBase
	{
		private readonly IBancoService _bancoService;
		private readonly IMapper _mapper;
		private readonly ILogger<BancosController> _logger;

		public BancosController(IBancoService bancoService, IMapper mapper, ILogger<BancosController> logger)
		{
			_bancoService = bancoService;
			_mapper = mapper;
			_logger = logger;
			_logger.LogDebug(1, "NLog injected into HomeController"); 
		}

		[HttpGet]
		public async Task<IEnumerable<BancoResource>> GetAllAsync()
		{
			_logger.LogInformation("Una prueba desde GetAllAsync()");
			var bancos = await _bancoService.ListAsync().ConfigureAwait(true);
			var resources = _mapper.Map<IEnumerable<Banco>, IEnumerable<BancoResource>>(bancos);

			return resources;
		}

		[HttpPost]
		public async Task<IActionResult> PostAsync([FromBody] BancoGrabarResource resource)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState.GetErrorMessages());
			var banco = _mapper.Map<BancoGrabarResource, Banco>(resource);


			var result = await _bancoService.SaveAsync(banco).ConfigureAwait(true);

			if (!result.Success)
				return BadRequest(result.Message);

			var bancoResource = _mapper.Map<Banco, BancoResource>(result.Banco);
			return Ok(bancoResource);

		}

		[HttpPut("{BancoId}")]
		public async Task<IActionResult> PutAsync(int BancoId, [FromBody] BancoGrabarResource resource)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState.GetErrorMessages());

			var banco = _mapper.Map<BancoGrabarResource, Banco>(resource);
			var result = await _bancoService.UpdateAsync(BancoId, banco).ConfigureAwait(true);

			if (!result.Success)
				return BadRequest(result.Message);

			var bancoResource = _mapper.Map<Banco, BancoResource>(result.Banco);
			return Ok(bancoResource);
		}

		[HttpDelete("{BancoId}")]
		public async Task<IActionResult> DeleteAsync(int bancoId)
		{
			var result = await _bancoService.DeleteAsync(bancoId).ConfigureAwait(true);

			if (!result.Success)
				return BadRequest(result.Message);

			var bancoResource = _mapper.Map<Banco, BancoResource>(result.Banco);
			return Ok(bancoResource);
		}
	}
}
