using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ALPPI.Models {
    public class Materia {
        [Key]
        public int idMateria { get; set; }


        [Required(ErrorMessage = "Esse campo não pode ser Vazio/Nullo")]
        [Display(Name = "Nome")]
        public string nme_Materia { get; set; }


        [Required(ErrorMessage = "Esse campo não pode ser Vazio/Nullo")]
        [Display(Name = "Descricao")]
        [DataType(DataType.Text)]
        public string des_Materia { get; set; }

        #region Collections
        public virtual ICollection<Licao> licoes { get; set; }
        #endregion
    }
}