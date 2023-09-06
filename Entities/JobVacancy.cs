using StoneApi.Entities.Base;

namespace StoneApi.Entities
{
    public class JobVacancy : BaseEntity
    {
        public override int Id { get; set; }
        public override string Name { get; set; }
        public Department? Department { get; set; }
        public List<Candidate>? Candidates { get; set; }
        public HrSpecialist? HrSpecialist { get; set; }
        public bool IsClosed { get; set; }
    }
}
