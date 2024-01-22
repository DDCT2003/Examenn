using Examen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Examen.Service
{
    public class APIService
    {
        public static string _baseUrl;
        public HttpClient _httpClient;

        public APIService()
        {

            _baseUrl = "https://apiproyecto20231127081349.azurewebsites.net/";
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(_baseUrl);
        }

        public async Task<List<Tarea>> GetTarea(string Nombre,string Estado)
        {
            var response = await _httpClient.GetAsync($"/api/Tarea/{Nombre}/{Estado}");
            if (response.IsSuccessStatusCode)
            {
                var json_response = await response.Content.ReadAsStringAsync();
                List<Tarea> tareas = JsonConvert.DeserializeObject<List<Tarea>>(json_response);
                return tareas;
            }
            return new List<Tarea>();
        }

        public async Task<List<Tarea>> GetTareas()
        {
            var response = await _httpClient.GetAsync("/api/Tarea");
            if (response.IsSuccessStatusCode)
            {
                var json_response = await response.Content.ReadAsStringAsync();
                List<Tarea> tareas = JsonConvert.DeserializeObject<List<Tarea>>(json_response);
                return tareas;
            }
            return new List<Tarea>();

        }

        public async Task<Tarea> PostTarea(Tarea tarea)
        {
            var content = new StringContent(JsonConvert.SerializeObject(tarea), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("/api/Tarea/", content);
            if (response.IsSuccessStatusCode)
            {
                var json_response = await response.Content.ReadAsStringAsync();
                Tarea tarea1 = JsonConvert.DeserializeObject<Tarea>(json_response);
                return tarea1;
            }
            return new Tarea();
        }



    }
}
