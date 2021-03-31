using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Places.Models.RandomUsers;

namespace Places.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public RandomUsers users { get; set; }
        private HttpClient httpClient = new HttpClient();

        public async Task<IActionResult> OnGetAsync()
        {
            RandomUsers data = null;
            HttpResponseMessage responseMessage = await httpClient
                .GetAsync("https://randomuser.me/api/?results=3");
            _logger.Log(LogLevel.Information, "test");
            if (responseMessage.IsSuccessStatusCode)
            {
                var dataj = await responseMessage.Content.ReadAsStreamAsync();



                data = await JsonSerializer.DeserializeAsync<Places.Models.RandomUsers.RandomUsers>(
                    dataj,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
                );
                _logger.Log(LogLevel.Information, data.ToString());
            }
            users = data;
            return Page();
        }
    }
}
