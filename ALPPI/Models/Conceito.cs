using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ALPPI.Models {
    public class Conceito {
        [Key]
        public int idConceito { get; set; }

        [Required(ErrorMessage = "Esse campo não pode ser Vazio/Nullo")]
        [Display(Name = "Nome")]
        public string nme_Conceito { get; set; }

        #region Collections
        public virtual ICollection<Licao> licoes { get; set; }
        #endregion
    }
}