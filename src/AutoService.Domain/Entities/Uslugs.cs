using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoService.Domain.Entities
{
    public class Uslugs
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public Guid CategorId { get; set; }
        public string About { get; set; }
        public Guid ServiceId { get; set; }
        public virtual Category Category { get; set; }
        public virtual Service Service { get; set; }
    }
}
