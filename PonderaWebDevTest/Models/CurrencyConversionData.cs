using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PonderaWebDevTest.Models
{
    public class CurrencyConversionInput
    {
        [Required]
        [StringLength(50, ErrorMessage = "Country name cannot be longer than 50 characters.")]
        [Display(Name = "Source Country Name")]
        public string SourceCountry
        {
            get;
            set;
        }

        [Required]
        [StringLength(50, ErrorMessage = "Country name cannot be longer than 50 characters.")]
        [Display(Name = "Target Country Name")]
        public string TargetCountry
        {
            get;
            set;
        }

        [Required]
        [Display(Name = "Conversion Amount")]
        public decimal ConversionAmount
        {
            get;
            set;
        }        
    }

    public class CurrencyConversionData
    {
        public long Id
        {
            get;
            set;
        }

        [Required]
        [StringLength(50, ErrorMessage = "Country name cannot be longer than 50 characters.")]
        [Display(Name = "Source Country Name")]
        public string SourceCountry
        {
            get;
            set;
        }

        [Required]
        [StringLength(50, ErrorMessage = "Country name cannot be longer than 50 characters.")]
        [Display(Name = "Source Country Currency")]
        public string SourceCountryCurrency
        {
            get;
            set;
        }

        [Required]
        [Display(Name = "Source Country Exchange Rate")]
        public decimal SourceCountryExchangeRate
        {
            get;
            set;
        }

        [Required]
        [StringLength(50, ErrorMessage = "Country name cannot be longer than 50 characters.")]
        [Display(Name = "Target Country Name")]
        public string TargetCountry
        {
            get;
            set;
        }

        [Required]
        [StringLength(50, ErrorMessage = "Country name cannot be longer than 50 characters.")]
        [Display(Name = "Target Country Currency")]
        public string TargetCountryCurrency
        {
            get;
            set;
        }

        [Required]
        [Display(Name = "Source Country Exchange Rate")]
        public decimal TargetCountryExchangeRate
        {
            get;
            set;
        }

        [Required]
        public decimal ConversionAmount
        {
            get;
            set;
        }
    }
}