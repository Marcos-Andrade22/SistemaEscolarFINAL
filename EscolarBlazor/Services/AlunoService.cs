using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace EscolarBlazor.Services
{
    public class AlunoService
    {
        private readonly HttpClient _httpClient;

        public AlunoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Aluno>> GetAlunosAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Aluno>>("api/alunos");
        }
    }
}
