using AutoService.Domain.Entities.Auth;
using AutoService.Domain.Entities.Models.ServiceModels;
using AutoService.Domain.Entities.Models.UserModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoService.Domain.Entities.Models.CompanyModels
{
    public class Company
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string CompanyName { get; set; }

        public string PhotoPath { get; set; }

        [MaxLength(2000)]
        public string CompanyHistory {  get; set; }
        public Guid OwnerId { get; set; }


        public virtual User User { get; set; }
        public virtual List<CompanyCategory> CompanyCategories { get; set; }
        public virtual List<Service> Services { get; set; }


    }
}
