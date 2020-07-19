using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Localization;


using ByblosMiPH.API.Domain.Models;
using ByblosMiPH.API.Domain.Repositories;
using ByblosMiPH.API.Domain.Services;
using ByblosMiPH.API.Domain.Services.Communication;

namespace ByblosMiPH.API.Services
{
	public class BancoService : IBancoService
	{
		private readonly IBancoRepository _bancoRepository;
		private readonly IUnitOfWork _unitOfWork;
		private readonly IStringLocalizer<Banco> _localizer;

		public BancoService(IBancoRepository bancoRepository, IUnitOfWork unitOfWork, IStringLocalizer<Banco> localizer)
		{
			_bancoRepository = bancoRepository;
			_unitOfWork = unitOfWork;
			_localizer = localizer;
		}

		public async Task<IEnumerable<Banco>> ListAsync()
		{
			return await _bancoRepository.ListAsync();
		}

		public async Task<BancoResponse> SaveAsync(Banco banco)
		{
			try
			{
				await _bancoRepository.AddAsync(banco);
				await _unitOfWork.CompleteAsync();

				return new BancoResponse(banco);
			}
			catch (Exception ex)
			{
				// Do some logging stuff
//				return new BancoResponse($"An error occurred when saving the banco: {ex.Message}");
				return new BancoResponse(_localizer["BancoErrorGrabando"] + ex.Message);
			}
		}

		public async Task<BancoResponse> UpdateAsync(int bancoId, Banco banco)
		{
			if (banco == null)
				return new BancoResponse(_localizer["BancoEsNulo"]);

			var existingBanco = await _bancoRepository.FindByIdAsync(bancoId);

			if (existingBanco == null)
				return new BancoResponse(_localizer["BancoNotFound"]);

			existingBanco.Nombre = banco.Nombre;
			existingBanco.Código = banco.Código;

			try
			{
				_bancoRepository.Update(existingBanco);
				await _unitOfWork.CompleteAsync();

				return new BancoResponse(existingBanco);
			}
			catch (Exception ex)
			{
				// Do some logging stuff
//				return new BancoResponse($"An error occurred when updating the banco: {ex.Message}");
				return new BancoResponse(_localizer["BancoErrorActualizando"] + ex.Message);
			}
		}

		public async Task<BancoResponse> DeleteAsync(int bancoId)
		{
			var existingBanco = await _bancoRepository.FindByIdAsync(bancoId);

			if (existingBanco == null)
				return new BancoResponse(_localizer["BancoNotFound"]);

			try
			{
				_bancoRepository.Remove(existingBanco);
				await _unitOfWork.CompleteAsync();

				return new BancoResponse(existingBanco);
			}
			catch (Exception ex)
			{
				// Do some logging stuff
//				return new BancoResponse($"An error occurred when deleting the banco: {ex.Message}");
				return new BancoResponse(_localizer["BancoErrorEliminando"] + ex.Message);
			}
		}

	}
}
