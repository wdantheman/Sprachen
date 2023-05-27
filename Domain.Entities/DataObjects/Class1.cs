using System;
using System.Collections.Generic;

abstract internal class TranslationComponent
{
    protected string text;
}

class Word : TranslationComponent
{
    protected List<string> translations;
    public Word(string text)
    {
        this.text = text;
    }
    // Here goes some kind of translation service interface instead of the string of lenguage, 
}

class TranslationGroup : TranslationComponent
{

    private List<TranslationComponent> translations = new List<TranslationComponent>();

    public void AddTranslation(TranslationComponent translation)
    {
        translations.Add(translation);
    }

    public void RemoveTranslation(TranslationComponent translation)
    {
        translations.Remove(translation);
    }
}
