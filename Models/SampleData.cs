using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BibliotekaProgmat.Models
{
    public class SampleData : DropCreateDatabaseIfModelChanges<BibliotekaContext>
    {
        protected override void Seed(BibliotekaContext context)
        {
            var ksiazki = new List<Ksiazka>
            {
                new Ksiazka { Autor="Marek Marecki", DataWydania=new DateTime(2010,03,02),Nazwa="Twoje Okulary",Opis="Ksiazka o okularach i przygodach z wywrotką"},
                new Ksiazka { Autor="Wojtek Marecki", DataWydania=new DateTime(2014,06,02),Nazwa="Twoje Czapki",Opis="Ksiazka o czapkach i przygodach z zakrętem"}
            };
            context.Ksiazki.AddRange(ksiazki);
        }
    }
}