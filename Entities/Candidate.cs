using StoneApi.Entities.Base;

namespace StoneApi.Entities
{
    public class Candidate : BaseEntity
    {
        public override int Id { get; set; }
        public override string Name { get; set; }
        public string Source { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public bool IsTestRequired { get; set; }
        public bool IsHired { get; set; }
    }
}
