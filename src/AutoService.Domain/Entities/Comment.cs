using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoService.Domain.Entities
{
    public class Comment
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Avto { get; set; }
        public Guid ServiceId { get; set; }
        public Guid UslugaId { get; set; }
        public string favor { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public virtual Service Service { get; set; }
        public virtual Uslugs Usluga { get; set; }
    }
}
