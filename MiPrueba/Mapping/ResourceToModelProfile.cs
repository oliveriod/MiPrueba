using AutoMapper;
using ByblosMiPH.API.Domain.Models;
using ByblosMiPH.API.Resources;


namespace ByblosMiPH.API.Mapping
{
	public class ResourceToModelProfile : Profile
	{
		public ResourceToModelProfile()
		{
			CreateMap<BancoGrabarResource, Banco>();
		}
	}
}
