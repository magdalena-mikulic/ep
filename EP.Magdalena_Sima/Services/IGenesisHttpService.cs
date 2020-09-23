using System.Collections.Generic;
using System.Threading.Tasks;
using EP.Magdalena_Sima.Models;
using EP.Magdalena_Sima.Models.Termin;

namespace EP.Magdalena_Sima.Services
{
    public interface IGenesisHttpService
    {
        Task<List<TerminViewModel>> GetAsync();

        Task<ExtendedModel> GetByIdAsync(string id);

        Task UpdateAsync(ExtendedModel model);

        Task CreateAsync(TerminFields model);

        Task DeleteAsync(string id);
    }
}