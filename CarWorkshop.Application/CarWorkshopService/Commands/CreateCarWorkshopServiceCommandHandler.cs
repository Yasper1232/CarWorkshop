using CarWorkshop.Application.ApplicationUser;
using CarWorkshop.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Application.CarWorkshopService.Commands
{
    public class CreateCarWorkshopServiceCommandHandler : IRequestHandler<CreateCarWorkshopServiceCommand>
    {
        private readonly ICarWorkshopRepository _repository;
        private readonly IUserContext _userContext;
        private readonly ICarWorkshopServiceRepository _carWorkshopServiceRepository;
        public CreateCarWorkshopServiceCommandHandler(ICarWorkshopRepository repository,IUserContext userContext, ICarWorkshopServiceRepository carWorkshopServiceRepository) 
        {
            _repository = repository;   
            _userContext = userContext;
            _carWorkshopServiceRepository = carWorkshopServiceRepository;
        }
        public async Task<Unit> Handle(CreateCarWorkshopServiceCommand request, CancellationToken cancellationToken)
        {
            
            var carWorkshop = await _repository.GetCarWorkshopByEncodedName(request.CarWorkshopEncodedName);
            var user = _userContext.GetCurrentUser();
            var isEditable = user != null && (carWorkshop.CreatedById == user.Id || user.IsInRole("Moderator"));

            if (!isEditable)
            {
                return Unit.Value;

            }

            var carWorkshopService = new Domain.Entities.CarWorkshopService()
            {
                Cost = request.Cost,
                Description = request.Description,
                CarWorkshopId = carWorkshop.Id,
            };

            await _carWorkshopServiceRepository.Create(carWorkshopService);

            return Unit.Value;

        }
    }
}
