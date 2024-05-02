using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoService.Domain.Entities.Models.ShopModels.CarSeatModels
{
    public class CarSeat
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid CategoryId { get; set; }
        public Guid BrandId { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public virtual CarSeatCategory CarSeatCategory { get; set; }
        public virtual CarSeatBrand CarSeatBrand { get; set; }
    }
}
