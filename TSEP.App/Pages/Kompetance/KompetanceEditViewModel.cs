using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace TSEP.App.Pages.Kompetance
{
    public class KompetanceEditViewModel
    {
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Beskrivelse")]
        public string Description { get; set; }
        public int Id { get; set; }
        public byte[] RowVersion { get; set; }
    }
}
