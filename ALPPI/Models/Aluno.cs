using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ALPPI.Models {
    public class Aluno {
        [Key]
        public int idAluno { get; set; }

        [Required(ErrorMessage = "Esse campo não pode ser Vazio/Nullo")]
        [Display(Name = "Nome")]
        public string nme_Aluno { get; set; }

        [Required(ErrorMessage = "Esse campo não pode ser Vazio/Nullo")]
        [Display(Name = "Matricula")]
        public long matricula_Aluno { get; set; }

        [Required(ErrorMessage = "Esse campo não pode ser Vazio/Nullo")]
        [Display(Name = "CPF")]
        public long cpf_Aluno { get; set; }

        [Required(ErrorMessage = "Esse campo não pode ser Vazio/Nullo")]
        [Display(Name = "Data de Nascimento")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "dd/MM/yyyy")]
        public DateTime dta_NascAluno { get; set; }

        public int flg_Inativo { get; set; }

        #region Foreing Keys
        public Cidade cidade { get; set; }
        public Sexo sexo { get; set; }
        public Turma turma { get; set; }
        #endregion

        #region Collections
        public virtual ICollection<Resposta> respostas { get; set; }
        #endregion
    }
}