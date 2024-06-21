using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using SharedModels.Models;

namespace SeuProjetoBlazor.Services
{
    public class TurmaService
    {
        private readonly HttpClient _httpClient;

        public TurmaService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Turma>> GetTurmasAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Turma>>("api/turmas");
        }
    }
}
