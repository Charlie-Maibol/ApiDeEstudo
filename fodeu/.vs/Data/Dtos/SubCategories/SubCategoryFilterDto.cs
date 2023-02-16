namespace EccomerceAPI.Data.Dtos.SubCategories
{
    public class SubCategoryFilterDto
    {
        public string name;
        public bool? status;
        public int? order;
        public int pageNumber = 0;
        public int itensPerPage = 0;
        public int? CategoryId;
    }
}
