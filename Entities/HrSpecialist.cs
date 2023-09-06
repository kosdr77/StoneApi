using StoneApi.Entities.Base;
using StoneApi.Entities.Interfaces;

namespace StoneApi.Entities
{
    public class HrSpecialist : BaseEntity, IJob
    {
        public override int Id { get; set; }
        public override string Name { get; set; }
        public Department Department { get; set; }
        public string JobTitle { get; set; }
        public string JobDescription { get; set; }
        public string Expirience { get; set; }
        public int ClosedVacancies { get; set; }
        public decimal MotivationFactor { get; set; }

        public void UpdateMotivation()
        {
            MotivationFactor = CalculateMotivationFactor();
        }

        private decimal CalculateMotivationFactor()
        {
            return ClosedVacancies * 0.1m;
        }
    }
}
