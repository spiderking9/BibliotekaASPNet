using BibliotekaProgmat.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BibliotekaProgmat.Models
{
    public class BibliotekaContext : DbContext
    {
        public BibliotekaContext() : base("name=DefaultConnection") { }
        public static BibliotekaContext Create()
        {
            return new BibliotekaContext();
        }
        public DbSet<Ksiazka> Ksiazki { get; set; }
        public DbSet<Rezerwacja> Rezerwacje { get; set; }
    }
}