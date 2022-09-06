using System.ComponentModel.DataAnnotations;

namespace EccomerceAPI.Data.Dtos.DC
{
    public class SearchDistributionCentersDto
    {
        [Key]
        [Required]
        public int Id { get; internal set; }
        [Required(ErrorMessage = "Campo Obrigatório")]
        [StringLength(128, ErrorMessage = "Você excedeu o número da caracteres permitidos!")]
        [RegularExpression(@"^[a-zA-Z' '-'\s]{1,40}$")]
        public string Name { get; set; }
        public bool Status { get; set; } = true;

        public string City { get; set; }

        public string UF { get; set; }

        public int ZipCode { get; set; }

        public string Street { get; set; }
        public int StreetNumber { get; set; }
        public string Neighbourhood { get; set; }
        
    }
}
