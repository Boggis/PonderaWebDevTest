using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PonderaWebDevTest.Models
{
    public class CountryData
    {
        [Key]
        public long Id
        {
            get;
            set;
        }

        [Required]
        [Column("Code")]
        [Display(Name = "Country Code")]
        public int Code
        {
            get;
            set;
        }

        [Required]
        [StringLength(50, ErrorMessage = "Country name cannot be longer than 50 characters.")]
        [Column("CountryName")]
        [Display(Name = "Country Name")]
        public string CountryName
        {
            get;
            set;
        }

        [Required]
        [StringLength(5, ErrorMessage = "Currency name cannot be longer than 5 characters.")]
        [Column("CurrencyName")]
        [Display(Name = "Currency Short Name")]
        public string CurrencyName
        {
            get;
            set;
        }
    }
}