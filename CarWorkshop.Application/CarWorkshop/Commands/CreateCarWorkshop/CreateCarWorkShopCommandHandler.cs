﻿using AutoMapper;
using CarWorkshop.Application.ApplicationUser;

using CarWorkshop.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace CarWorkshop.Application.CarWorkshop.Commands.CreateCarWorkshop
{
    public class CreateCarWorkShopCommandHandler : IRequestHandler<CreateCarWorkshopCommand>
    {
        private readonly IMapper _mapper;
        private readonly ICarWorkshopRepository _carWorkshopRepository;
        private readonly IUserContext _userContext;

        public CreateCarWorkShopCommandHandler(IMapper mapper,ICarWorkshopRepository carWorkshopRepository, IUserContext userContext)
        {
            _mapper = mapper;
            _carWorkshopRepository = carWorkshopRepository;
            _userContext = userContext;

        }
        public async Task<Unit> Handle(CreateCarWorkshopCommand request, CancellationToken cancellationToken)
        {


            var carWorkshop = _mapper.Map<Domain.Entities.CarWorkshop>(request);
            carWorkshop.EncodeName();


            carWorkshop.CreatedById = _userContext.GetCurrentUser().Id;

            await _carWorkshopRepository.Create(carWorkshop);

            return Unit.Value;
        }
    }
}
