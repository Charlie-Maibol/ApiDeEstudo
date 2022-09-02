using AutoMapper;
using EccomerceAPI.Data;
using EccomerceAPI.Data.productDao;
using Microsoft.Extensions.Configuration;

namespace EccomerceAPI.Services
{
    public class DcServices
    {
        private AppDbContext _context;
        private DcDao _DcDao;
        private IMapper _mapper;

        public DcServices(AppDbContext context, IMapper mapper, DcDao dao, IConfiguration configuration)
        {
            _context = context;
            _mapper = mapper;
            _DcDao = dao;



        }
    }
}
