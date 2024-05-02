using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoService.Domain.Entities
{
    public class Model
    {
        public Guid Id { get; set; }
        [EmailAddress]
        public string Email {  get; set; }
        public string Marka { get; set; }
        public string Models {  get; set; }
        public string YearOfEntry { get; set; }
        public int vipcod { get; set; }
        public string Problem { get; set; }
        public bool Check {  get; set; }
    }
}
