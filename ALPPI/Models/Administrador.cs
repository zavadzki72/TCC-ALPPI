using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ALPPI.Models {
    public class Administrador {
        [Key]
        public int idAdminitrador { get; set; }

        [Required(ErrorMessage = "Esse campo não pode ser Vazio/Nullo")]
        [Display(Name = "Nome")]
        public string nme_Administrador { get; set; }

        [Required(ErrorMessage = "Esse campo não pode ser Vazio/Nullo")]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string eml_Administrador { get; set; }

        [Required(ErrorMessage = "Esse campo não pode ser Vazio/Nullo")]
        [Display(Name = "Senha (Minimo 4 carcateres)")]
        [DataType(DataType.Password)]
        [StringLength(100,MinimumLength = 4)]
        public string senha_Administrador { get; set; }
    }
}