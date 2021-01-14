using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CompareAttribute = System.Web.Mvc.CompareAttribute;
using Compare = System.ComponentModel.DataAnnotations.CompareAttribute;


namespace DSRtri.Models
{
    public class Registracija
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "To ne sme biti prazno!")]
        [StringLength(20, ErrorMessage = "Največ 20 znakov!")]
        private string firstName;

        [Required(AllowEmptyStrings = false, ErrorMessage = "To ne sme biti prazno!")]
        [StringLength(30, ErrorMessage = "Največ 30 znakov!")]
        private string lastName;

        [Required(AllowEmptyStrings = false, ErrorMessage = "To ne sme biti prazno!")]
        private DateTime dateOfBirth;

        [Required(AllowEmptyStrings = false, ErrorMessage = "To ne sme biti prazno!")]
        private string placeOfBirth;

        [MaxLength(13)]
        [MinLength(13)]
        [RegularExpression("[^0-9]", ErrorMessage = "Samo številke!")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "To ne sme biti prazno!")]
        private float emso;

        [Required(AllowEmptyStrings = false, ErrorMessage = "To ne sme biti prazno!")]
        private int age;

        [Required(AllowEmptyStrings = false, ErrorMessage = "To ne sme biti prazno!")]
        private string address;

        [Required(AllowEmptyStrings = false, ErrorMessage = "To ne sme biti prazno!")]
        private string postArea;

        [DataType(DataType.PostalCode)]
        [RegularExpression("[a-zA-Z0-9]")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "To ne sme biti prazno!")]
        private int postalCode;

        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                  @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                  @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",
                  ErrorMessage = "E-mail je neustrezen!")] 
    
        [Required(AllowEmptyStrings = false, ErrorMessage = "To ne sme biti prazno!")]
        private string email;

        [Required]
        [DataType(DataType.Password)]
        private string password;

        [DataType(DataType.Password, ErrorMessage = "Gesli nista enaki!")]
        //[System.ComponentModel.DataAnnotations.Compare("Password")] 
        //[Compare("Password")]
        private string confirmedPassword;

        [Required(AllowEmptyStrings = false, ErrorMessage = "To ne sme biti prazno!")]
        private string country;


        public Registracija()
        {
        }

        public Registracija(
            string ime,
            string priimek,
            DateTime date,
            string krajRojstva,
            float emso,
            int vrednost,
            string posta,
            string naslov,
            int pstevilka,
            string drzava,
            string enaslov,
            string gesloena,
            string geslodva)
        {
            FirstName = ime;
            LastName = priimek;
            DateOfBirth = date;
            PlaceOfBirth = krajRojstva;
            Emso = emso;
            Age = vrednost;
            Address = naslov;
            PostArea = posta;
            PostalCode = pstevilka;
            Country = drzava;
            Email = enaslov;
            Password = gesloena;
            ConfirmedPassword = geslodva;
        }
        
        public string FirstName
        {
            get{ return firstName; }
            set{ firstName = value; }
        }
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }
        public DateTime DateOfBirth
        {
            get { return dateOfBirth; }
            set { dateOfBirth = value; }
        }

        public string PlaceOfBirth
        {
            get { return placeOfBirth; }
            set { placeOfBirth = value; }
        }

        public float Emso
        {
            get { return emso; }
            set { emso = value; }
        }
        public int Age
        {
            get { return age; }
            set { age = value; }
        }
        public string Address
        {
            get { return address; }
            set { address = value; }
        }
        public string PostArea
        {
            get { return postArea; }
            set { postArea = value; }
        }
        public int PostalCode
        {
            get { return postalCode; }
            set { postalCode = value; }
        }
        public string Country
        {
            get { return country; }
            set { country = value; }
        }
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        public string ConfirmedPassword
        {
            get { return confirmedPassword; }
            set { confirmedPassword = value; }
        }

        public static IEnumerable<SelectListItem> GetItems()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            list.Add(new SelectListItem { Text = "Kranj", Value = "Kr" });
            SelectListItem item = new SelectListItem();
            list.Add(item);
            yield return new SelectListItem { Text = "Ljubljana", Value = "Lj" };
            yield return new SelectListItem { Text = "Maribor", Value = "Mb" };
            yield return new SelectListItem { Text = "Celje", Value = "Ce" };
            yield return new SelectListItem { Text = "Murska Sobota", Value = "Ms" };
            yield return new SelectListItem { Text = "Novo Mesto", Value = "Nm" };
            yield return new SelectListItem { Text = "Postojna", Value = "Po" };
            yield return new SelectListItem { Text = "Koper", Value = "Kp", Selected = true };
        }
    }
}