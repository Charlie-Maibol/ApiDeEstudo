using EccomerceAPI.Models;

namespace EccomerceAPI.Data.Dtos.Products
{
    public class DistributionCenterFilterDto
    {
        public int? id { get; set; }
        public string name { get; set; }
        public bool? status { get; set; }
        public string city { get; set; }
        public string UF { get; set; }
        public string zipCode { get; set; }
        public string street { get; set; }
        public int? streetNumber { get; set; }
        public string neighbourhood { get; set; }
        public string addComplemente { get; set; }
        public int pageNumber { get; set; }
        public int itensPerPage { get; set; }
        public string order { get; set; }
        public string orderName { get; set; }
        public string  product { get; set; }
        public string  subCategory { get; set; }
    }
}
