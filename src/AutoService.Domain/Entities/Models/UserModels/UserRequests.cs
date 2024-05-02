using AutoService.Domain.Entities.Models.AutoServiceModels;
using AutoService.Domain.Entities.Models.ServiceModels;
namespace AutoService.Domain.Entities.Models.UserModels
{
    public class UserRequests
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid UserId { get; set; }
        public Guid AutoServiceId { get; set; }
        public Guid ServiceId { get; set; }
        public virtual User User { get; set; }
        public virtual Service Service { get; set; }
        public virtual AutoServiceModel AutoService { get; set; }
    }
}
