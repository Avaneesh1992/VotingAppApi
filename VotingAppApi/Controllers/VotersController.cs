using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VotingAppApi.DTOs;
using VotingAppApi.Model;
using VotingAppApi.Services;

namespace VotingAppApi.Controllers
{
    [ApiController]
    [Route("api/voters")]
    public class VotersController : ControllerBase
    {
        private readonly IVotingService _service;

        public VotersController(IVotingService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetVoters()
        {
            var result = await _service.GetVotersAsync();
            return Ok(new VotingAppApi.Model.ApiResponse<List<Voter>>(
                StatusCodes.Status200OK,
                result
            ));
            
        }
        

        [HttpPost]
        public IActionResult Post(VoterDto dto)
        {
            _service.AddVoterAsync(dto.Name);
            return Ok();
        }
    }

}
