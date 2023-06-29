using Domain.Entities.DataObjects;

namespace Domain.Entities.PersistenceServices
{
    public interface ILanguagesComponentSettingsService
    {
        public LanguagesComponent GetLanguagesComponentFromDocument();
        public void SetLanguagesComponentInDocument();
    }
}
