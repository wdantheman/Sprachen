

namespace Domain.Entities.DataObjects.EntryComposite
{
    public record Entry
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public List<SpeechContext> SpeechContext { get; set; }

        public Entry(int id, string content)
        {
            Id = id;
            Content = content;
            SpeechContext = new List<SpeechContext>();
        }
        public Entry(int id, string content, List<SpeechContext> speechContext)
        {
            Id= id;
            Content = content;
            SpeechContext = speechContext;
        }
    }
}
