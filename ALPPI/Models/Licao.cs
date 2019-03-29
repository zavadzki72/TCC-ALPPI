using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ALPPI.Models {
    public class Licao {
        [Key]
        public int idLicao { get; set; }

        [Required(ErrorMessage = "Esse campo não pode ser Vazio/Nullo")]
        [Display(Name = "Nome")]
        public string nme_Licao { get; set; }

        [Required(ErrorMessage = "Esse campo não pode ser Vazio/Nullo")]
        [Display(Name = "Data Inicio")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "dd/MM/yyyy")]
        public DateTime dta_Inicio_Licao { get; set; }

        [Required(ErrorMessage = "Esse campo não pode ser Vazio/Nullo")]
        [Display(Name = "Data Conclusao")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "dd/MM/yyyy")]
        public DateTime Dta_Conclusao_Licao { get; set; }

        public int flg_Ativo { get; set; }

        #region Foreing Keys
        public Professor professor { get; set; }
        public Turma turma { get; set; }
        public Materia materia { get; set; }
        public Conceito conceito { get; set; }
        #endregion

        #region Collections
        public virtual ICollection<Pergunta> perguntas { get; set; }
        #endregion
    }
}