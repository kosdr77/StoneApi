using Microsoft.AspNetCore.Routing.Matching;
using StoneApi.Entities.Base;

namespace StoneApi.Entities
{
    public class Department : BaseEntity
    {
        public override int Id { get; set; }
        public override string Name { get; set; }
        public List<Specialist> Specialists { get; set; }
    }
}
