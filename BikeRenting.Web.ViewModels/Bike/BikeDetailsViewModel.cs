using BikeRenting.Web.ViewModels.Agent;

namespace BikeRenting.Web.ViewModels.Bike
{
    public class BikeDetailsViewModel : BikeAllViewModel
    {
        public string Description { get; set; } = null!;

        public string Category { get; set; } = null!;

        public AgentInfoOnBikeViewModel Agent { get; set; } = null!;

    }
}
