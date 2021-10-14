

using System.Text.Json;
using RegisterSupervisorNotificationsLibrary.Models;
using RegisterSupervisorNotificationsLibrary.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace RegisterSupervisorNotificationsLibrary.Services
{
    public class SupervisorRepo : ISupervisorRepo
    {
        private readonly IHttpClientFactory _clientFactory;
        private const string APIENDPOINT = "api/managers";
        public SupervisorRepo(IHttpClientFactory httpClientFactory)
        {
            _clientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
        }

        public async Task<IEnumerable<Supervisor>> GetSupervisors()
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, APIENDPOINT);
            HttpClient client = _clientFactory.CreateClient("supervisors");

            HttpResponseMessage response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                return await JsonSerializer.DeserializeAsync<IEnumerable<Supervisor>>(responseStream);
            }
            else
            {
                return Enumerable.Empty<Supervisor>();
            }
        }
    }
}
