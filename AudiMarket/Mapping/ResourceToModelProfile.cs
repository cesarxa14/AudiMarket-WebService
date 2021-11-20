using AudiMarket.Domain.Models;
using AudiMarket.Resources;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AudiMarket.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SaveCategoryResource, Category>();
            CreateMap<SaveMusicProducerResource, MusicProducer>();
            CreateMap<SavePublicationResource, Publication>();
            CreateMap<SavePayMethodResource, PayMethod>();
            CreateMap<SaveVoucherResource, Voucher>();
            CreateMap<SavePlayListResource, PlayList>();
            CreateMap<SaveProjectResource, Project>();
        }
        
    }
}
