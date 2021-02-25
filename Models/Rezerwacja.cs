using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BibliotekaProgmat.Models
{
    public class Rezerwacja
    {
        [Key]
        public int IdRezerwacji { get; set; }

        [ForeignKey("Ksiazka")]
        public int IdKsiazki { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DataRezerwacji { get; set; }
        public string IdUser { get; set; }
        public virtual Ksiazka Ksiazka { get; set; }
    }
}