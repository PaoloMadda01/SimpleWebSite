using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProgettoAPI.Models
{
    public class Category
    {
        [Key]   //è l'id delle righe dei dati aggiunti nella tabella. è un attributo
        public int id { get; set; }
        [Required]      //attributo che è richiesto, non opzionale. è riferito a Name
        public string Name { get; set; }
        [DisplayName("Display Order")] //in questo modo quando verrà scritto DisplayOrder verrà scritto con lo spazio
        [Range(1,100, ErrorMessage ="Error, out from the range")]  //fa parte della classe RangeAttribute
        public int DisplayOrder { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;  //valore di Default 
    }
}
