using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoService.Domain.Entities
{
    public class Aksiya
    {
        public Guid Id { get; set; }
        public string Path {  get; set; }
        public DateTime ExpireDate { get; set; }
    }
}
