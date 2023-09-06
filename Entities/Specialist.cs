using StoneApi.Entities.Base;
using StoneApi.Entities.Interfaces;

namespace StoneApi.Entities
{
    public class Specialist : BaseEntity, IJob
    {
        public override int Id { get; set; }
        public override string Name { get; set; }
        public Department Department { get; set; }
        public string Expirience { get; set; }
        public string JobTitle { get; set; }
        public string JobDescription { get; set; }
    }
}