using System.ComponentModel.DataAnnotations;

namespace BikeRenting.Web.ViewModels.Agent
{
    public class AgentInfoOnBikeViewModel
    {
        public string FullName { get; set; } = null!;

        public string Email { get; set; } = null!;

        [Display(Name = "Phone")]
        public string PhoneNumber { get; set; } = null!;
    }
}
