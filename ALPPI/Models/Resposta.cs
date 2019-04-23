using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ALPPI.Models {
    public class Resposta {
        [Key]
        public int idResposta { get; set; }

        [Required(ErrorMessage = "Esse campo não pode ser Vazio/Nullo")]
        [Display(Name = "Resposta")]
        [DataType(DataType.Text)]
        public string des_Resposta { get; set; }

        public int nota { get; set; }

        [DefaultValue(false)]
        public bool isEnviado { get; set; }

        #region Foreing Key
        public Aluno aluno { get; set; }
        public Pergunta pergunta { get; set; }
        #endregion
    }
}