using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CleanArch.Application.ViewModels
{
    public class ProductViewModel 
    {
        public int Id { set; get; }

        [Required(ErrorMessage = "O nome é requirido")]
        [MinLength(3)]
        [MaxLength(100)]
        [DisplayName("Name")]
        public String Name { set; get; }

        [Required(ErrorMessage = "A Descricao é requirido")]
        [MinLength(3)]
        [MaxLength(100)]
        [DisplayName("Descricao")]
        public String Description { set; get; }

        [Required(ErrorMessage = "o Preco é requirido")]
        [Range(1, 9999.99)]
        [MaxLength(100)]
        [DisplayFormat(DataFormatString="{0:C2}")]
        [DisplayName("Preco")]
        public decimal Price { set; get; }    
    }
}
