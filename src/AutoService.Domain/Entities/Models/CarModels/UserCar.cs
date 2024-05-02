using AutoService.Domain.Entities.Models.UserModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoService.Domain.Entities.Models.CarModels
{
    public class UserCar
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid UserId { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public DateTimeOffset ProdYear { get; set; }
        public string VINcode { get; set; }
    }
}
