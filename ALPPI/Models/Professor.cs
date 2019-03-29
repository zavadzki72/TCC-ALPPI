using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ALPPI.Models {
    public class Professor {
        [Key]
        public int idProfessor { get; set; }

        [Required(ErrorMessage = "Esse campo não pode ser Vazio/Nullo")]
        [Display(Name = "Nome")]
        public string nme_Professor { get; set; }


        [Required(ErrorMessage = "Esse campo não pode ser Vazio/Nullo")]
        [Display(Name = "Matricula")]
        public long matricula_Professor { get; set; }


        [Required(ErrorMessage = "Esse campo não pode ser Vazio/Nullo")]
        [Display(Name = "CPF")]
        public long cpf_Professor { get; set; }


        [Required(ErrorMessage = "Esse campo não pode ser Vazio/Nullo")]
        [Display(Name = "Data de Nacimento")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "dd/MM/yyyy")]
        public DateTime dta_NascProfessor { get; set; }

        public int flg_Inativo { get; set; }

        [Required(ErrorMessage = "Esse campo não pode ser Vazio/Nullo")]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string eml_Professor { get; set; }

        [Required(ErrorMessage = "Esse campo não pode ser Vazio/Nullo")]
        [Display(Name = "Senha (Minimo 4 carcateres)")]
        [DataType(DataType.Password)]
        [StringLength(100, MinimumLength = 4)]
        public string senha_Professor { get; set; }

        #region Foreing Keys
        public Cidade cidade { get; set; }
        public Sexo sexo { get; set; }
        #endregion

        #region Collections
        public virtual ICollection<Licao> licoes { get; set; }
        #endregion
    }
}