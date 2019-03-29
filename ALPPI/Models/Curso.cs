using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ALPPI.Models {
    public class Curso {
        [Key]
        public int idCurso { get; set; }

        [Required(ErrorMessage = "Esse campo não pode ser Vazio/Nullo")]
        [Display(Name = "Nome")]
        public string nme_Curso { get; set; }

        [Required(ErrorMessage = "Esse campo não pode ser Vazio/Nullo")]
        [Display(Name = "Descricao")]
        [DataType(DataType.Text)]
        public string des_Curso { get; set; }

        public int flg_Inativo { get; set; }

        #region Collections
        public virtual ICollection<Turma> turmas { get; set; }
        #endregion
    }
}