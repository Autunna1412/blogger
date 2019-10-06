using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Blogger.Infrastructure.Persistence.Models;

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
