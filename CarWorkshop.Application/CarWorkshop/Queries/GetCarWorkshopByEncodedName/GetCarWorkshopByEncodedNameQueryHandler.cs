using CarWorkshop.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarWorkshop.Application;
using AutoMapper;
using Microsoft.AspNetCore.Http.Timeouts;

namespace CarWorkshop.Application.CarWorkshop.Queries.GetCarWorkshopByEncodedName
{
	public class GetCarWorkshopByEncodedNameQueryHandler : IRequestHandler<GetCarWorkshopByEncodedNameQuery, CarWorkshopDto>
	{
		private readonly ICarWorkshopRepository _carWorkshopRepository;
		private readonly IMapper _mapper;
        public GetCarWorkshopByEncodedNameQueryHandler(ICarWorkshopRepository carWorkshopRepository, IMapper mapper)
        {
			_carWorkshopRepository = carWorkshopRepository;   
			_mapper = mapper;
        }
        public async Task<CarWorkshopDto> Handle(GetCarWorkshopByEncodedNameQuery request, CancellationToken cancellationToken)
		{

			var carWorkShop = await _carWorkshopRepository.GetCarWorkshopByEncodedName(request.EncodedName);

			var dto = _mapper.Map<CarWorkshopDto>(carWorkShop);

			return dto;


		}
	}
}
