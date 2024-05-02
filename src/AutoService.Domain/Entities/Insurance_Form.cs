using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoService.Domain.Entities
{
    public class Insurance_Form
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string City { get; set; }
        public string phoneNumber { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string CarKuzov {  get; set; }
        public int Mass { get; set; }
        public string Category { get; set; }
        public string Mark { get; set; }
        public string VinNumber { get; set; } 
        public string DocumentVinNumber {  get; set; }
        public string CarModel {  get; set; }
        public string FuelType { get; set; }
        public string Seria { get; set; }
        public string Caryear {  get; set; }
        public string GiventBy {  get; set; }

    }
}
