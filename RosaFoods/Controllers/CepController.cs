using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace RosaFoods.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CepController : ControllerBase
    {
        [HttpGet("{cep}")]
        public async Task<IActionResult> GetCepInfo(string cep)
        {
            if (cep.Length != 8)
            {
                return BadRequest("O CEP deve conter 8 dígitos.");
            }

            string url = $"https://viacep.com.br/ws/{cep}/json/";

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(url);

                if (!response.IsSuccessStatusCode)
                {
                    return BadRequest("Não foi possível buscar o CEP.");
                }

                string json = await response.Content.ReadAsStringAsync();
                var cepInfo = JsonConvert.DeserializeObject(json);

                return Ok(cepInfo);
            }
        }
    }
}
