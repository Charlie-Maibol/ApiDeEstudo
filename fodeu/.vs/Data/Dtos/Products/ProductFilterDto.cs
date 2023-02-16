using Microsoft.AspNetCore.Mvc;

namespace EccomerceAPI.Data.Dtos
{
    public class ProductFIlterDto
    {

        public string name;
        public string center;
        public bool? status;
        public double? weight;
        public double? height;
        public double? lengths;
        public double? widths;
        public double? price;
        public int? amountOfProducts;
        public int? order;
        public int pageNumber = 0;
        public int itensPerPage = 0;

    }
}
