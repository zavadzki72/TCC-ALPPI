using ALPPI.Helpers;
using ALPPI.Helpers.CustomValidations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.UI.WebControls;

namespace ALPPI.Models {
    public class Aluno {
        [Key]
        public int idAluno { get; set; }

        [Required(ErrorMessage = "Esse campo não pode ser Vazio/Nullo")]
        [Display(Name = "Nome")]
        public string nme_Aluno { get; set; }

        [Required(ErrorMessage = "Esse campo não pode ser Vazio/Nullo")]
        [Display(Name = "Matricula")]
        [CustomValidationNumber(ErrorMessage = "Esse campo deve ser preenchido somente com numeros")]
        [MinLength(11, ErrorMessage = "Esse campo tem que ter 11 digitos")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Esse campo deve ser preenchido somente com numeros")]
        public long matricula_Aluno { get; set; }

        [Required(ErrorMessage = "Esse campo não pode ser Vazio/Nullo")]
        [Display(Name = "CPF")]
        [CustomValidationCPF(ErrorMessage = "CPF inválido")]
        [RegularExpression(@"^[0-9.-]*$", ErrorMessage = "Esse campo deve ser preenchido somente com numeros")]
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