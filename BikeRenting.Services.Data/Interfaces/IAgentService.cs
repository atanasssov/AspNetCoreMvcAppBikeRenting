using BikeRenting.Web.ViewModels.Agent;

namespace BikeRenting.Services.Data.Interfaces
{
    public interface IAgentService
    {
        Task<bool> AgentExistsByUserIdAsync(string userId);

        Task<bool> AgentExistsByPhoneNumberAsync(string phoneNumber);

        Task<bool> HasRentsByUserIdAsync(string userId);

        Task Create(string userId, BecomeAgentFormModel model);

        Task<string?> GetAgentIdByUserIdAsync(string userId);

        Task<bool> HasBikeWithIdAsync(string? userId, string bikeId);

        // to be changed
        Task<string> GetAgentEmailByBikeIdAsync(string bikeId);
    }
}
