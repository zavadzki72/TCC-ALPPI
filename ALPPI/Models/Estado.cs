using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ALPPI.Models {
    public class Estado {
        [Key]
        public int idEstado { get; set; }

        [Required(ErrorMessage = "Esse campo não pode ser Vazio/Nullo")]
        [Display(Name = "Nome")]
        public string nme_Estado { get; set; }

        [Required(ErrorMessage = "Esse campo não pode ser Vazio/Nullo")]
        [Display(Name = "Sigla")]
        public string sigla_Estado { get; set; }

        #region Collections
        public virtual ICollection<Cidade> cidades { get; set; }
        #endregion
    }
}