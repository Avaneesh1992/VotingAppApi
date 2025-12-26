using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Refit;
using VotingAppApi.DTOs;
using VotingAppApi.Model;
using VotingAppApi.Services;

namespace VotingAppApi.Controllers
{
    [ApiController]
    [Route("api/candidates")]
    public class CandidatesController : ControllerBase
    {
        private readonly IVotingService _service;

        public CandidatesController(IVotingService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetCandidates()
        {
            var result = await _service.GetCandidatesAsync();
            return Ok(new VotingAppApi.Model.ApiResponse<List<Candidate>>(
                StatusCodes.Status200OK,
                result
            ));
            //return Ok(new ApiResponse<List<Candidate>>(
            //    StatusCodes.Status200OK,
            //    result
            //));
        }

        [HttpPost]
        public IActionResult Post(CandidateDto dto)
        {
            _service.AddCandidateAsync(dto.Name);
            return Ok();
        }
    }

}
