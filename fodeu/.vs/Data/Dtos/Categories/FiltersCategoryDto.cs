namespace EccomerceAPI.Data.Dtos.Categories
{
    public class FiltersCategoryDto
    {
        public string name;
        public bool? status;
        public int? order;
        public int pageNumber = 0;
        public int itensPerPage = 0;
    }
}
