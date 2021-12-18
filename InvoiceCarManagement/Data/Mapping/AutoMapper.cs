using AutoMapper;
using InvoiceCarManagement.Dto;
using InvoiceCarManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvoiceCarManagement.Data.Mapping
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<InvoiceProduct, InvoiceProductDto>();
            CreateMap<InvoiceProductDto, InvoiceProduct>();

            CreateMap<InvoiceDetails, InvoiceDetailsDto>();
            CreateMap<InvoiceDetailsDto, InvoiceDetails>();

        }
    }
}
