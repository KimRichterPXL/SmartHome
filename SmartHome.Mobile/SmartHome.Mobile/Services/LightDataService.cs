using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SmartHome.Mobile.Constanten;
using SmartHome.Mobile.Models;
using SmartHome.Mobile.Repository;

namespace SmartHome.Mobile.Services
{
    public interface ILightDataService
    {
        Task<IEnumerable<Light>> GetAllLightsAsync();
    }

    public class LightDataService : ILightDataService
    {
        private readonly IGenericRepository _repository;

        public LightDataService(IGenericRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Light>> GetAllLightsAsync()
        {
            UriBuilder builder = new UriBuilder(ApiConstants.BaseApiUrl)
            {
                Path = ApiConstants.LightEndPoint
            };

            var lights = await _repository.GetAsync<List<Light>>(builder.ToString());

            return lights;
        }
    }
}
