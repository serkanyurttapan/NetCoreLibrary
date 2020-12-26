using AutoMapper;
using FluentValidationApp.Web.DTOs;
using FluentValidationApp.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FluentValidationApp.Web.Mapping.ModelProfile
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<Customer, CustomerDto>().ReverseMap();
            // Bunu yazmak yerine ReverseMap(); ekledim yukarıya bu şekilde kendisi tersinin de olacağını söyler.
            //CreateMap<CustomerDto, Customer>();

            /*İki tabloyu Maplerken propertyleri farklı yazsam bile aynı propertyleri eşleştirmek isteyebilirim.
            Bunu yapabilmek için ise aşağıdaki metod kullanılır.
            fakat bunu yapmak performası kötü yönde etkiler.

            CreateMap<CustomerDto, Customer>().ForMember(dest => dest.Age, opt => opt.MapFrom(z => z.Yas));

             */
        }
    }
}
