

namespace MyPrintiverse.Core
{
    public interface IBaseModel
    {
        public string Id { get; set; }

        public DateTime CreatedAt { get; }
        public long CreatedAtTicks { get; set; }

        public DateTime EditedAt { get;  }
        public long EditedAtTicks { get; set; }
    }
}
