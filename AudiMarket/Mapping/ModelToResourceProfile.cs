using AudiMarket.Domain.Models;
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
            CreateMap<Category, CategoryResource>();
            CreateMap<MusicProducer, MusicProducerResource>();
            CreateMap<VideoProducer, VideoProducerResource>();
            CreateMap<Publication, PublicationResource>();
            CreateMap<Review, ReviewResource>();
            CreateMap<Project, ProjectResource>();
            CreateMap<PayMethod, PayMethodResource>();
            CreateMap<Voucher, VoucherResource>();
            CreateMap<PlayList, PlayListResource>();
        }
    }
}
