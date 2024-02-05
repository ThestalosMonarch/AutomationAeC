namespace Automation.Domain.Models
{
    /// <summary>
    /// Ao analisar o site alura percebi que existem 
    /// diversos tipo de conteudo, sendo assim preparei 
    /// esta classe para que no futuro seja possivel faciltiar a inserção de outros tipos
    /// </summary>
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