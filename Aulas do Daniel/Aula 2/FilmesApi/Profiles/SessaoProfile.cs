using AutoMapper;
using FilmesApi.Data.Dtos.Sessao;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesAPI.Profiles
{
    public class SessaoProfile : Profile
    {
        public SessaoProfile()
        {
            CreateMap<CreateSessaoDto, Cinema>();
            CreateMap<Cinema, ReadSessaoDto>();
            
        }
    }
}
