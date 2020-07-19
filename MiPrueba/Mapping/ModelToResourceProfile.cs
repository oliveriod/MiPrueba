using AutoMapper;
using ByblosMiPH.API.Domain.Models;
using ByblosMiPH.API.Resources;

namespace ByblosMiPH.API.Mapping
{
	public class ModelToResourceProfile : Profile
	{
		public ModelToResourceProfile()
		{
			CreateMap<Banco, BancoResource>();

		}
	}
}



