using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using ASP_Client.Models;

namespace ASP_Client.Controllers
{
    public class PeopleController : Controller
    {

        string URI = "https://localhost:7274/api/People";
        HttpClient client = new HttpClient();

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            client.BaseAddress = new Uri(URI);
            string peopleStr = await client.GetStringAsync(URI);
            var peoples = JsonConvert.DeserializeObject<List<People>>(peopleStr);
            return View(peoples);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(People people)
        {
            client.BaseAddress = new Uri(URI);
            people.Id = Guid.NewGuid();
            var result = await client.PostAsJsonAsync("", people);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            client.BaseAddress = new Uri(URI+"/"+id);
            string peopleStr = await client.GetStringAsync("");
            var people = JsonConvert.DeserializeObject<People>(peopleStr);
            return View(people);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Guid id, People people)
        {
            client.BaseAddress = new Uri(URI + "/" + id);
            var result = await client.PutAsJsonAsync("", people);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            client.BaseAddress = new Uri(URI + "/" + id);
            var result = await client.DeleteAsync("");
            return RedirectToAction(nameof(Index));
        }
    }
}

