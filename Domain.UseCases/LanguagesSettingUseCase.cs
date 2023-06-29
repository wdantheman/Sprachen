using Domain.Entities;
using Domain.Entities.DataObjects;
using Domain.Entities.PersistenceServices;

namespace Domain.UseCases
{
    public class LanguagesSettingUseCase
    {
        internal ILanguagesComponentSettingsService LanguagesComponentSettingsService;
        public LanguagesSettingUseCase(ILanguagesComponentSettingsService settingsServices)
        {
            LanguagesComponentSettingsService = settingsServices;
        }
        public void AddTargetLanguageToDocLanguagesComponent(int documentId, Language langauge)
        {
            LanguagesComponent temp = LanguagesComponentSettingsService.GetLanguagesComponentFromDocument(documentId);
            temp.AddTargetLanguage(langauge);
            LanguagesComponentSettingsService.SetLanguagesComponentInDocument(temp, documentId);
        }

        public void RemoveTargetLanguageToDocLanguagesComponent(int documentId, Language langauge)
        {
            LanguagesComponent temp = LanguagesComponentSettingsService.GetLanguagesComponentFromDocument(documentId);
            temp.RemoveTargetLanguage(langauge);
            LanguagesComponentSettingsService.SetLanguagesComponentInDocument(temp, documentId);
        }
        public void SetSourceLanguageInDocumentLanguagesComponent(int documentId, Language newLanguage) 
        {
            LanguagesComponent temp = LanguagesComponentSettingsService.GetLanguagesComponentFromDocument(documentId);
            temp.SetSourceLanguage(newLanguage);
            LanguagesComponentSettingsService.SetLanguagesComponentInDocument(temp, documentId);
        }
        public void AddTargetLanguageToDocSubsectionLanguagesComponent(int documentId, int subsectionId, Language langauge)
        {
            LanguagesComponent temp = LanguagesComponentSettingsService.GetLanguagesComponentFromDocumentSubsection(documentId, subsectionId);
            temp.AddTargetLanguage(langauge);
            LanguagesComponentSettingsService.SetLanguagesComponentInDocumentSubsection(temp, documentId, subsectionId);
        }
        public void RemoveTargetLanguageToDocSubsectionLanguagesComponent(int documentId, int subsectionId, Language langauge)
        {
            LanguagesComponent temp = LanguagesComponentSettingsService.GetLanguagesComponentFromDocumentSubsection(documentId, subsectionId);
            temp.RemoveTargetLanguage(langauge);
            LanguagesComponentSettingsService.SetLanguagesComponentInDocumentSubsection(temp, documentId, subsectionId);
        }
        public void SetSourceLanguageInDocumentSubsectionLanguagesComponent(int documentId, int subsectionId, Language langauge) 
        {
            LanguagesComponent temp = LanguagesComponentSettingsService.GetLanguagesComponentFromDocumentSubsection(documentId, subsectionId);
            temp.SetSourceLanguage(langauge);
            LanguagesComponentSettingsService.SetLanguagesComponentInDocumentSubsection(temp, documentId, subsectionId);
        }
    }
}
