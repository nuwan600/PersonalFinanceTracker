using AutoMapper;
using PFT.Entities.Domain;
using PFT.Entities.Domain.Enums;
using PFT.Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PFT.Infrastructure.Helpers
{
    public class TransactionProfile : Profile
    {
        public TransactionProfile()
        {
            CreateMap<Transactions, TransactionDto>()
               .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type.ToString()));

            CreateMap<TransactionDto, Transactions>()
                .ForMember(dest => dest.Type,
                    opt => opt.MapFrom(src => Enum.Parse<TransactionType>(src.Type)));
        }
    }
}
