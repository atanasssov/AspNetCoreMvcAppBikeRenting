using BikeRenting.Web.ViewModels.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeRenting.Services.Data.Interfaces
{
    public interface IBikeService
    {
        Task<IEnumerable<IndexViewModel>> LastThreeBikesAsync();
    }
}
