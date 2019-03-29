using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ALPPI.Models {
    public class Cidade {
        [Key]
        public int idCidade { get; set; }

        [Required(ErrorMessage = "Esse campo não pode ser Vazio/Nullo")]
        [Display(Name = "Nome")]
        public string nme_Cidade { get; set; }

        #region Foreing Keys
        public Estado estado { get; set; }
        #endregion

        #region Collections
        public virtual ICollection<Aluno> alunos { get; set; }
        public virtual ICollection<Professor> professores { get; set; }
        #endregion
    }
}