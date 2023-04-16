using Microsoft.AspNetCore.Mvc;

namespace EccomerceAPI.Data.Dtos
{
    public class CartFilterDto
    {
        public int? order;
        public int pageNumber = 0;
        public int itensPerPage = 0;
        public int? id { get; set; }
        public bool? status { get; set; }
        public string city { get; set; }
        public string UF { get; set; }
        public string zipCode { get; set; }
        public string street { get; set; }
        public int? streetNumber { get; set; }
        public string neighbourhood { get; set; }
        public string addComplemente { get; set; }

    }
}
