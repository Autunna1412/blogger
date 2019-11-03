using AutoMapper;
using Blogger.Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;


namespace Blogger.Core.Application.Mapper
{
    public abstract class MappingProfileBase<TModel, TViewModel> : Profile
         where TModel : BaseEntity
         where TViewModel : class
    {
        public MappingProfileBase()
        {

        }
    }
}
