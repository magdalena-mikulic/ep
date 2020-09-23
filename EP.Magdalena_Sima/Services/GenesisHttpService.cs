using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Cache;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using EP.Magdalena_Sima.Models;
using EP.Magdalena_Sima.Models.Termin;
using EP.Magdalena_Sima.Settings;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RestSharp;

namespace EP.Magdalena_Sima.Services
{
    public class GenesisHttpService : IGenesisHttpService
    {
        private readonly IMapper _mapper;
        private readonly HttpSettings _settings;

        public GenesisHttpService(IOptions<HttpSettings> settings, IMapper mapper)
        {
            _mapper = mapper;
            _settings = settings.Value;
        }

        public async Task<List<TerminViewModel>> GetAsync()
        {
            var client = GetGenesisClient();

            var cancellationTokenSource = new CancellationTokenSource();

            var request = new RestRequest("/v3.0/type/APPOINTMENT/list", Method.GET, DataFormat.Json);

            var restResponse = await client.ExecuteAsync(request, cancellationTokenSource.Token);

            var response = JsonConvert.DeserializeObject<List<TerminViewModel>>(restResponse.Content);

            return response;
        }

        public async Task<ExtendedModel> GetByIdAsync(string id)
        {
            var client = GetGenesisClient();

            var cancellationTokenSource = new CancellationTokenSource();

            var request = new RestRequest($"/v3.0/type/APPOINTMENT/{id}", Method.GET, DataFormat.Json);

            var restResponse = await client.ExecuteAsync(request, cancellationTokenSource.Token);

            var response = JsonConvert.DeserializeObject<TerminViewModel>(restResponse.Content);

            var result = _mapper.Map<TerminFields, ExtendedModel>(response.Fields);

            result.Etag = restResponse.Headers.FirstOrDefault(x => x.Name.ToUpperInvariant() == "ETAG")?.Value.ToString();

            return result;
        }

        public async Task UpdateAsync(ExtendedModel model)
        {
            var client = GetGenesisClient();

            var cancellationTokenSource = new CancellationTokenSource();

            var request = new RestRequest($"/v3.0/type/APPOINTMENT/{model.GGUID}", Method.PUT, DataFormat.Json);

            request.AddHeader("If-Match", model.Etag);

            var body = _mapper.Map<ExtendedModel, TerminRequest>(model);

            var data = new { fields = body };

            var serialized = JsonConvert.SerializeObject(data);

            request.AddJsonBody(serialized);

            await client.ExecuteAsync(request, cancellationTokenSource.Token);
        }

        public async Task CreateAsync(TerminFields model)
        {
            var client = GetGenesisClient();

            var cancellationTokenSource = new CancellationTokenSource();

            var request = new RestRequest("/v3.0/type/APPOINTMENT", Method.POST, DataFormat.Json);

            var body = _mapper.Map<TerminFields, TerminRequest>(model);

            var data = new { fields = body };

            var serialized = JsonConvert.SerializeObject(data);

            request.AddJsonBody(serialized);

            await client.ExecuteAsync(request, cancellationTokenSource.Token);
        }

        public async Task DeleteAsync(string id)
        {
            var client = GetGenesisClient();

            var cancellationTokenSource = new CancellationTokenSource();

            var request = new RestRequest($"/v3.0/type/APPOINTMENT/{id}", Method.DELETE, DataFormat.Json);

            await client.ExecuteAsync(request, cancellationTokenSource.Token);
        }

        private RestClient GetGenesisClient()
        {
            var encoding = new UTF8Encoding();

            var client = new RestClient(_settings.Url) {CachePolicy = new RequestCachePolicy(RequestCacheLevel.Default)};


            var authInfo = Convert.ToBase64String(encoding.GetBytes(_settings.Username + ":" + _settings.Password));

            client.AddDefaultHeader("Authorization", $"Basic {authInfo}");
            client.AddDefaultHeader("X-CAS-PRODUCT-KEY", _settings.ProductKey);
            client.Timeout = 15000;

            return client;
        }
    }
}