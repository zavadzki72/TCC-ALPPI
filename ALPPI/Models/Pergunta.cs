using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ALPPI.Models {
    public class Pergunta {
        [Key]
        public int idPergunta { get; set; }

        [Required(ErrorMessage = "Esse campo não pode ser Vazio/Nullo")]
        [Display(Name = "Pergunta")]
        public string des_Pergunta { get; set; }

        [Required(ErrorMessage = "Esse campo não pode ser Vazio/Nullo")]
        [Display(Name = "Resposta padrao")]
        public string des_Resposta_Padrao_Pergunta { get; set; }

        #region Foreing Keys
        public Licao licao { get; set; }
        #endregion

        #region Collections
        public virtual ICollection<Resposta> respostas { get; set; }
        #endregion

    }
}