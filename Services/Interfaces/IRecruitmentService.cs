using StoneApi.Entities;

namespace StoneApi.Services.Interfaces
{
    public interface IRecruitmentService
    {
        void CreateVacancy(JobVacancy vacancy);
        void AddCandidate(int vacancyId, Candidate candidate);
        void AssignTest(int candidateId, int vacancyId);
        void HireCandidate(int candidateId, int vacancyId);
        public Candidate GetCandidateById(int candidateId, int vacancyId);

        public HrSpecialist GetHrSpecialistById(int hrId);

        public JobVacancy GetVacancyById(int vacancyId);
        public IEnumerable<JobVacancy> GetVacanciesByHrSpecialistId(int hrSpecialistId);
    }
}
