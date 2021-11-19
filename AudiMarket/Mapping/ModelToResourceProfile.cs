using AudiMarket.Domain.Models;
using AudiMarket.Domain.Services.Communications;
using AudiMarket.Resources;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AudiMarket.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<MusicProducer, MusicProducerResource>();
            CreateMap<MusicProducer, AuthenticateResponse>();
            CreateMap<Publication, PublicationResource>();
        }
    }
}
