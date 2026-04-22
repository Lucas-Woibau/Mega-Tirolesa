namespace MegaTirolesa.Domain.Entities
{
    public abstract class BaseEntity
    {
        protected BaseEntity() { }

        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; }
        public bool IsDeleted { get; set; } = false;

        public void SetAsDeleted()
        {
            IsDeleted = true;
        }
    }
}
