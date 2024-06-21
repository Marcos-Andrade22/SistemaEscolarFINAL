using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using SharedModels.Models;

namespace SeuProjetoBlazor.Services
{
    public class ProfessorService
    {
        private readonly HttpClient _httpClient;

        public ProfessorService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Professor>> GetProfessoresAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Professor>>("api/professores");
        }
    }
}
