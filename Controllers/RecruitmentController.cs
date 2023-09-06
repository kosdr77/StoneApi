using Microsoft.AspNetCore.Mvc;
using StoneApi.Entities;
using StoneApi.Services.Interfaces;

namespace StoneApi.Controllers
{
    [Route("api/recruitment")]
    [ApiController]
    public class RecruitmentController : ControllerBase
    {
        private readonly IRecruitmentService _recruitmentService;

        public RecruitmentController(IRecruitmentService recruitmentService)
        {
            _recruitmentService = recruitmentService ?? throw new ArgumentNullException(nameof(recruitmentService));
        }

        [HttpPost("create-vacancy")]
        public IActionResult CreateVacancy([FromBody] JobVacancy vacancy)
        {
            try
            {
                _recruitmentService.CreateVacancy(vacancy);
                return Ok("Vacancy created successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed to create vacancy: {ex.Message}");
            }
        }

        [HttpPost("add-candidate/{vacancyId}")]
        public IActionResult AddCandidate(int vacancyId, [FromBody] Candidate candidate)
        {
            try
            {
                _recruitmentService.AddCandidate(vacancyId, candidate);
                return Ok("Candidate added successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed to add candidate: {ex.Message}");
            }
        }

        [HttpPost("assign-test/{candidateId}")]
        public IActionResult AssignTest(int candidateId, int vacancyId)
        {
            try
            {
                _recruitmentService.AssignTest(candidateId, vacancyId);
                return Ok("Test assigned successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed to assign test: {ex.Message}");
            }
        }

        [HttpPost("hire-candidate/{candidateId}")]
        public IActionResult HireCandidate(int candidateId, int vacancyId)
        {
            try
            {
                _recruitmentService.HireCandidate(candidateId, vacancyId);
                return Ok("Candidate hired successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed to hire candidate: {ex.Message}");
            }
        }

        [HttpGet("get-candidate/{candidateId}")]
        public IActionResult GetCandidate(int candidateId, int vacancyId)
        {
            try
            {
                var candidate = _recruitmentService.GetCandidateById(candidateId, vacancyId);
                return candidate == null ? NotFound("Candidate not found.") : Ok(candidate);
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed to get candidate: {ex.Message}");
            }
        }

        [HttpGet("get-hr-specialist/{hrSpecialistId}")]
        public IActionResult GetHrSpecialist(int hrSpecialistId)
        {
            try
            {
                var hrSpecialist = _recruitmentService.GetHrSpecialistById(hrSpecialistId);

                return hrSpecialist == null ? NotFound("HR Specialist not found.") : Ok(hrSpecialist);
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed to get HR Specialist: {ex.Message}");
            }
        }

        [HttpGet("get-vacancy/{vacancyId}")]
        public IActionResult GetVacancy(int vacancyId)
        {
            try
            {
                var vacancy = _recruitmentService.GetVacancyById(vacancyId);

                return vacancy == null ? NotFound("Vacancy not found.") : Ok(vacancy);
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed to get vacancy: {ex.Message}");
            }
        }

        [HttpGet("get-vacancies-by-hr-specialist/{hrSpecialistId}")]
        public IActionResult GetVacanciesByHrSpecialist(int hrSpecialistId)
        {
            try
            {
                var vacancies = _recruitmentService.GetVacanciesByHrSpecialistId(hrSpecialistId);
                return Ok(vacancies);
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed to get vacancies: {ex.Message}");
            }
        }
    }
}
