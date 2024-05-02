using AutoService.Domain.Entities.Models.ServiceModels;
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

        public List<Guid> CompanyCategoryId { get; set; }

        public List<Guid> ServiceId { get; set; }
    }
}
