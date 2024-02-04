namespace Automation.Domain.Models
{
    public abstract class AluraContent
    {
        public string title { get; private set; }
        public string description { get; private set; }

        protected AluraContent(string title, string description)
        {
            this.title = title;
            this.description = description;
        }
    }
}