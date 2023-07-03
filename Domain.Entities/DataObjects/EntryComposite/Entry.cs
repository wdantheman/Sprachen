

namespace Domain.Entities.DataObjects.EntryComposite
{
    public record Entry
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public SpeechContext SpeechContext { get; set; }

        public Entry(int id, string content)
        {
            Id = id;
            Content = content;
        }
        public Entry(int id, string content, SpeechContext speechContext)
        {
            Id= id;
            Content = content;
            SpeechContext = speechContext;
        }
    }
}
