namespace ALPPI.Helpers {
    public class MessageHelper {
        public static string errorRequired(string label="") {
            return (string.IsNullOrEmpty(label)) ? "Esse campo não pode ser Vazio/Nullo" : $"O campo {label}, não pode ser vazio/nullo";
        }
    }
}