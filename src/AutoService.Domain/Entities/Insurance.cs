using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoService.Domain.Entities
{
    public class Insurance
    {
        public Guid Id { get; set; }
        public string Titel {  get; set; }
        public string Description {  get; set; }
        public string? PicturePath { get; set; }

    }
}
