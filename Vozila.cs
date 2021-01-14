using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DSRtri.Models
{
    public class Vozila
    {
        private int id;

        private string naziv;

        private string model;

        private double stKilometrov;

        private int prvaRegistracija;

        private int lastnik;


        [Key]
        public int Id { get => id; set => id = value; }
        [Display(Name = "Naziv")]
        [StringLength(20, ErrorMessage = "Maximum length is 20!")]
        public string Naziv { get => naziv; set => naziv = value; }
        [Display(Name = "Model")]
        public string Model { get => model; set => model = value; }
        [Display(Name = "Prevozenih kilometrov")]
        public double StKilometrov { get => stKilometrov; set => stKilometrov = value; }
        [Display(Name = "Prva registracija")]
        public int PrvaRegistracija { get => prvaRegistracija; set => prvaRegistracija = value; }
        public int Lastnik { get => lastnik; set => lastnik = value; }

        public Vozila()
        {

        }

        public Vozila(string naziv, string model, double stKilometrov, int prvaRegistracija, int lastnik)
        {
            this.naziv = naziv;
            this.model = model;
            this.stKilometrov = stKilometrov;
            this.prvaRegistracija = prvaRegistracija;
            this.lastnik = lastnik;
        }
    }
}