

using System.ComponentModel.DataAnnotations;

namespace AutoService.Domain.Entities.Models.NewsModels
{
    public class NewsComment
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        
        public Guid NewsId { get; set; }

        public string userFirstName { get; set; }
        
        public string userLastName { get; set; }

        [MaxLength(500)]
        public string Comment {  get; set; }
        public virtual News News { get; set; }
    }
}
