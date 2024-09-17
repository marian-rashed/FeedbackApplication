using FeedbackApplication.DTOs;
using FeedbackApplication.Models;
using FeedbackApplication.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FeedbackApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OpinionController : ControllerBase
    {
        private readonly IOpinionRepository _opinionRepository;

        public OpinionController(IOpinionRepository opinionRepository)
        {
            _opinionRepository = opinionRepository;
        }

        [HttpPost("AddOpinion")]
        public IActionResult AddOpinion(OpinionDTO opinionDTO)
        {
            Opinion opinion = new Opinion()
            {
                Message = opinionDTO.Message,
                Time= DateTime.Now,
            };
            _opinionRepository.Add(opinion);
            _opinionRepository.Save();

            return Ok(opinion);
        }

        [HttpGet("GetAll")]
        public IActionResult GetAllOpiniones() 
        { 
            return Ok(_opinionRepository.GetAll());
        }
    }
}
