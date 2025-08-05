﻿using AutoMapper;
using CarWorkshop.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Application.CarWorkshop.Queries.GetCarWorkshopByEncodedName
{
    public class GetCarWorkshopByEncodedNameQueryHandler : IRequestHandler<GetCarWorkshopByEncodedNameQuery, CarWorkshopDto>
    {
        private readonly ICarworkshopRepository _carWorkshopRepository;
        private readonly IMapper _mapper;

        public GetCarWorkshopByEncodedNameQueryHandler(
            ICarworkshopRepository carworkshopRepository,
            IMapper mapper)
        {
            _carWorkshopRepository = carworkshopRepository;
            _mapper = mapper;
        }

        public async Task<CarWorkshopDto> Handle(GetCarWorkshopByEncodedNameQuery request, CancellationToken cancellationToken)
        {
            var carWorkshop = await _carWorkshopRepository.GetByEncodedName(request.EncodedName);

            var dto = _mapper.Map<CarWorkshopDto>(carWorkshop);

            return dto;
        }
    }
}
