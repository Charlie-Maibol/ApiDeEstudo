using System.ComponentModel.DataAnnotations;

namespace EccomerceAPI.Data.Dtos.Products
{
    public class CreateProductDto
    {

        [Key]
        [Required]
        public int Id { get; internal set; }
        [Required(ErrorMessage = "Campo Obrigatório")]
        [StringLength(128, ErrorMessage = "Você excedeu o número da caracteres permitidos!")]
        [RegularExpression(@"^[a-zA-Z' '-'\s]{1,40}$")]
        public string Name { get; set; }
        public bool Status { get; set; } = true;
        [Required(ErrorMessage = "Campo Obrigatório")]
        public double Weight { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório")]
        public double Height { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório")]
        public double Price { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório")]
        public double Lengths { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório")]
        public double Widths { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório")]
        public int AmountOfProducts { get; set; }

        public int distribuitonCenterId { get; set; }
        public int subCategoryId { get; set; }
    }
}
