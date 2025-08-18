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
    public class CreateCarWorkshopCommandHandler : IRequestHandler<CreateCarWorkshopCommand> 
    {
        private readonly ICarworkshopRepository _carworkshopRepository;
        private readonly IMapper _mapper;
        private readonly IUserContext _userContext;

        public CreateCarWorkshopCommandHandler(
            ICarworkshopRepository carworkshopRepository,
            IMapper mapper,
            IUserContext userContext)
        {
            _carworkshopRepository = carworkshopRepository;
            _mapper = mapper;
            _userContext = userContext;
        }

        public async Task<Unit> Handle(CreateCarWorkshopCommand request, CancellationToken cancellationToken)
        {
            var carWorkshop = _mapper.Map<Domain.Entities.CarWorkshop>(request);

            var user = _userContext.GetCurrentUser();
            var isEditable = user != null && carWorkshop.CreatedById == user.Id;

            if (isEditable)
                return Unit.Value;

            carWorkshop.EncodeName();

            carWorkshop.CreatedById = _userContext.GetCurrentUser().Id;

            await _carworkshopRepository.Create(carWorkshop);

            return Unit.Value;
        }
    }
}
