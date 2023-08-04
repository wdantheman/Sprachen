using Domain.Entities.DataObjects.DocumentComposite;
using Domain.Entities.DataObjects.EntryComposite;

namespace Domain.UseCases.EntriesUseCases
{
    public interface IEntryInSectionCRUDUseCase
    {
        SectionComposite Section { get; }

        void AddEmptyEntryInSection();
        void AddEntryInSection(Entry entry);
        void AddNewEntryInSection(string content);
        void DeleateEntryByContent(string content);
        void DeleateEntryById(int entryId);
        Entry GetEntryByContent(string content);
        Entry GetEntrybyId(int id);
        void ResetSection(SectionComposite section);
        void UpdateEntryContentById(int entryId, string newEntryContent);
    }
}