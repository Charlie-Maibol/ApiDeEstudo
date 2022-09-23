namespace EccomerceAPI.Data.Dtos.Products
{
    public class DistributionCenterFilterDto
    {
        public string name;
        public bool? status;
        public string city;
        public string UF;
        public string zipCode;
        public string street;
        public int? streetNumber;
        public string neighbourhood;
        public string addComplemente;
        public int pageNumber = 0;
        public int itensPerPage = 0;
        public int? order;
    }
}
