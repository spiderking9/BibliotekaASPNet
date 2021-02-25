using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BibliotekaProgmat.Models
{
    public class Ksiazka
    {
        [Key]
        public int Idksiazki { get; set; }
        [Required(ErrorMessage = "Wpisz nazwę ksiazki")]
        [MaxLength(30, ErrorMessage = "Nazwa ksiazki powinna zawierać max 30 znaków")]
        public string Nazwa { get; set; }
        [Required(ErrorMessage = "Wpisz autora ksiazki")]
        [MaxLength(30, ErrorMessage = "Autor ksiazki powinien zawierać max 30 znaków")]
        public string Autor { get; set; }
        [Display(Name = "Data wydania")]
        [Required(ErrorMessage = "Podaj datę wydania książki")]
        public DateTime DataWydania { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string Opis { get; set; }
    }
}