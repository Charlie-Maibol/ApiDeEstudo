namespace EccomerceAPI.Data.Dtos.CartWithProducts
{
    public class CreateCartWithProducts
    {
        public int CartId { get; set; }
        

        public int ProductId { get; set; }
        public int AmountOfProducts { get; set; }

        public string ProductName { get; set; }
        public double IndividualPrice { get; set; }
    }
}
