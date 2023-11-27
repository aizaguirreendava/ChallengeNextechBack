using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using System.Net;
using System.Text;

namespace NewsApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StoriesController : ControllerBase
    {
        private readonly IStoriesService _storiesService;
        public StoriesController(IStoriesService storiesService)
        {
            _storiesService = storiesService;
        }

        [HttpGet(Name = "Stories")]
        public async Task<IActionResult> GetAsync()
        {
            List<Item> listItem = new List<Item>();
            try
            {
                listItem = await _storiesService.GetStories();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
             return Ok(listItem); ;
        }
    }
}