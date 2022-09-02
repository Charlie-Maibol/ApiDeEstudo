using AutoMapper;
using EccomerceAPI.Data;
using EccomerceAPI.Data.productDao;
using Microsoft.Extensions.Configuration;

namespace EccomerceAPI.Services
{
    public class DistribuitonCenterServices
    {
        private AppDbContext _context;
        private DistribuitonCenterDao _DcDao;
        private IMapper _mapper;

        public DistribuitonCenterServices(AppDbContext context, IMapper mapper, DistribuitonCenterDao dao, IConfiguration configuration)
        {
            _context = context;
            _mapper = mapper;
            _DcDao = dao;



        }
    }
}
