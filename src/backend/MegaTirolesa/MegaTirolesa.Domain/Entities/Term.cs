namespace MegaTirolesa.Domain.Entities
{
    public class Term : BaseEntity
    {
        protected Term() { }
        public Term(string title, string content, double version, bool isActive)
            : base()
        {
            Title = title;
            Content = content;
            Version = version;
            IsActive = isActive;
        }

        public string Title { get; private set; } = string.Empty;
        public string Content { get; private set; } = string.Empty;
        public double Version { get; private set; }
        public bool IsActive { get; private set; }

        public void Update(string title, string content, double version, bool isActive)
        {
            Title = title;
            Content = content;
            Version = version;
            IsActive = isActive;
        }
    }
}
