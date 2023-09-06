using StoneApi.Entities;
using StoneApi.Services.Interfaces;

namespace StoneApi.Services
{
    public class RecruitmentService : IRecruitmentService
    {
        // Здесь могли быть поля репозитортиев  
        private readonly List<JobVacancy> _vacancies;
        private readonly List<HrSpecialist> _hrSpecialists;

        public RecruitmentService()
        {
            _vacancies = new List<JobVacancy>();
            _hrSpecialists = new List<HrSpecialist>();

            // Добавляем тестовые данные для вакансий
            var itHrSpecialist = new HrSpecialist() { Id = 1, Name = "Le Qu Di", ClosedVacancies = 32 };
            var salesHrSpecialist = new HrSpecialist() { Id = 2, Name = "John Smith", ClosedVacancies = 18 };

            _hrSpecialists.Add(itHrSpecialist);
            _hrSpecialists.Add(salesHrSpecialist);

            var itVacancy = new JobVacancy()
            {
                Id = 1,
                Name = "Software Developer",
                Department = new Department() { Id = 1, Name = "IT", Specialists = new List<Specialist>() },
                IsClosed = false,
                HrSpecialist = itHrSpecialist,
                Candidates = new List<Candidate>()
            };

            var salesVacancy = new JobVacancy()
            {
                Id = 2,
                Name = "Sales Representative",
                Department = new Department() { Id = 2, Name = "Sales", Specialists = new List<Specialist>() },
                IsClosed = false,
                HrSpecialist = salesHrSpecialist,
                Candidates = new List<Candidate>()
            };

            // Добавляем тестовые данные для кандидатов
            var candidate1 = new Candidate()
            {
                Id = 1,
                Name = "Alice Johnson",
                Source = "HH.RU",
                PhoneNumber = "123-456-7890",
                Email = "alice@example.com",
                Description = "Experienced software developer",
                IsTestRequired = true,
                IsHired = false
            };

            var candidate2 = new Candidate()
            {
                Id = 2,
                Name = "Bob Smith",
                Source = "HH.RU",
                PhoneNumber = "987-654-3210",
                Email = "bob@example.com",
                Description = "Sales professional with 5 years of experience",
                IsTestRequired = false,
                IsHired = false
            };

            itVacancy.Candidates.Add(candidate1);
            salesVacancy.Candidates.Add(candidate2);

            _vacancies.Add(itVacancy);
            _vacancies.Add(salesVacancy);

            var itManagerHrSpecialist = new HrSpecialist() { Id = 3, Name = "Anna Lee", ClosedVacancies = 25 };
            var hrVacancy = new JobVacancy()
            {
                Id = 3,
                Name = "HR Manager",
                Department = new Department() { Id = 3, Name = "HR", Specialists = new List<Specialist>() },
                IsClosed = false,
                HrSpecialist = itManagerHrSpecialist,
                Candidates = new List<Candidate>()
            };

            var candidate3 = new Candidate()
            {
                Id = 3,
                Name = "Eva Brown",
                Source = "Glassdoor",
                PhoneNumber = "555-123-4567",
                Email = "eva@example.com",
                Description = "Experienced HR professional",
                IsTestRequired = false,
                IsHired = false
            };

            _hrSpecialists.Add(itManagerHrSpecialist);
            hrVacancy.Candidates.Add(candidate3);
            _vacancies.Add(hrVacancy);
        }

        public void CreateVacancy(JobVacancy vacancy)
        {
            vacancy.Id = _vacancies.Count + 1;
            vacancy.IsClosed = false;
            vacancy.Candidates = new List<Candidate>();
            vacancy.Department = new Department() { Id = 0, Name = "IT", Specialists = new List<Specialist>() };
            vacancy.HrSpecialist = new HrSpecialist() { Id = 0, Name = "Le Qu Di", ClosedVacancies = 32 };

            _vacancies.Add(vacancy);
        }

        public void AddCandidate(int vacancyId, Candidate candidate)
        {
            var vacancy = _vacancies.Find(v => v.Id == vacancyId);

            if (vacancy == null || vacancy.IsClosed)
            {
                throw new Exception("Vacancy not found or closed.");
            }

            candidate.Id = vacancy.Candidates.Count + 1;
            candidate.IsTestRequired = false;
            candidate.IsHired = false;

            vacancy.Candidates.Add(candidate);
        }

        public void AssignTest(int candidateId, int vacancyId)
        {
            var vacancy = _vacancies.FirstOrDefault(c => c.Id == vacancyId) ?? throw new Exception("Vacancy not found.");
            var candidate = vacancy.Candidates.Find(c => c.Id == candidateId) ?? throw new Exception("Candidate not found.");

            candidate.IsTestRequired = true;
        }

        public void HireCandidate(int candidateId, int vacancyId)
        {
            var vacancy = _vacancies.FirstOrDefault(c => c.Id == vacancyId) ?? throw new Exception("Vacancy not found.");
            var candidate = vacancy.Candidates.Find(c => c.Id == candidateId) ?? throw new Exception("Candidate not found.");

            candidate.IsHired = true;
            vacancy.IsClosed = true;

            vacancy.HrSpecialist.ClosedVacancies++;
            vacancy.HrSpecialist.UpdateMotivation();
        }

        public Candidate GetCandidateById(int candidateId, int vacancyId)
        {
            var vacancy = _vacancies.FirstOrDefault(c => c.Id == vacancyId) ?? throw new Exception("Vacancy not found.");

            return vacancy.Candidates.FirstOrDefault(c => c.Id == candidateId);
        }

        public HrSpecialist GetHrSpecialistById(int hrId)
        {
            return _hrSpecialists.FirstOrDefault(c => c.Id == hrId);
        }

        public JobVacancy GetVacancyById(int vacancyId)
        {
            return _vacancies.FirstOrDefault(v => v.Id == vacancyId);
        }

        public IEnumerable<JobVacancy> GetVacanciesByHrSpecialistId(int hrSpecialistId)
        {
            return _vacancies.Where(v => v.HrSpecialist.Id == hrSpecialistId);
        }
    }
}
