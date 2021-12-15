using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DevelopersController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public DevelopersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult GetPopularDevelopers([FromQuery] int count)
        {
            var popularDevelopers = _unitOfWork.Developers.GetPopularDevelopers(count);
            return Ok(popularDevelopers);
        }

        [HttpPost]
        public IActionResult AddDeveloperAndProject()
        {
            var dev = new Developer
            {
                Followers = 35,
                Name = "Erick Moura"
            };

            var project = new Project
            {
                Name = "MouraSoft"
            };

            _unitOfWork.Developers.Add(dev);
            _unitOfWork.Projects.Add(project);
            _unitOfWork.Commit();

            return Ok();
        }
    }
}
