using AutoService.Domain.Entities.Models.CompanyModels;

namespace AutoService.Domain.Entities.Models.AutoServiceModels
{
    public class AutoService
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Location { get; set; }
        public string WebSitePath { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public Guid CompanyId { get; set; }
        public virtual Company Company { get; set; }
    }
}
