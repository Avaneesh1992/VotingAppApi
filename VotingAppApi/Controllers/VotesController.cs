using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VotingAppApi.DTOs;
using VotingAppApi.Model;
using VotingAppApi.Services;

namespace VotingAppApi.Controllers
{
    [ApiController]
    [Route("api/vote")]
    public class VotesController : ControllerBase
    {
        private readonly IVotingService _service;

        public VotesController(IVotingService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult Vote(VoteRequestDto dto)
        {
            _service.CastVoteAsync(dto.CandidateId, dto.VoterId);
            return Ok(new VotingAppApi.Model.ApiResponse<string>(
            StatusCodes.Status200OK,
            "Vote cast successfully"            
             ));
        }
    }

}
