using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ALPPI.Models {
    public class Turma {
        [Key]
        public int idTurma { get; set; }

        [Required(ErrorMessage = "Esse campo não pode ser Vazio/Nullo")]
        [Display(Name = "Nome")]
        public string nme_Turma { get; set; }


        [Required(ErrorMessage = "Esse campo não pode ser Vazio/Nullo")]
        [Display(Name = "Data Inicio")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "dd/MM/yyyy")]
        public DateTime dta_InicioTurma { get; set; }


        [Required(ErrorMessage = "Esse campo não pode ser Vazio/Nullo")]
        [Display(Name = "Data Conclusao")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "dd/MM/yyyy")]
        public DateTime dta_ConclusaoTurma { get; set; }


        [Required(ErrorMessage = "Esse campo não pode ser Vazio/Nullo")]
        [Display(Name = "Ano")]
        public int ano_Turma { get; set; }

        public int flg_Inativo { get; set; }

        #region Foreing Keys
        public Curso curso { get; set; }
        #endregion

        #region Collections
        public virtual ICollection<Aluno> alunos { get; set; }
        public virtual ICollection<Licao> licoes { get; set; }
        #endregion
    }
}