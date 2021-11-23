using AudiMarket.Domain.Models;
using AudiMarket.Domain.Services.Communications;
using AudiMarket.Resources;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Threading.Tasks;

namespace AudiMarket.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SaveMusicProducerResource, MusicProducer>();
            CreateMap<RegisterRequest, MusicProducer>();
            CreateMap<UpdateRequest, MusicProducer>().ForAllMembers(options => options.Condition(
                (source, target, property) =>
                {
                    if (property == null) return false;
                    if (property.GetType() == typeof(string) && string.IsNullOrEmpty((string)property)) return false;
                    return true;
                }));
            CreateMap<SaveVideoProducerResource, VideoProducer>();
            CreateMap<SavePublicationResource, Publication>();
            CreateMap<SaveReviewResource, Review>();
            CreateMap<SavePayMethodResource, PayMethod>();
            CreateMap<SaveVoucherResource, Voucher>();
            CreateMap<SavePlayListResource, PlayList>();
            CreateMap<SaveProjectResource, Project>();
            CreateMap<SaveContractsResource,Contracts>();

        }
        
    }
}
