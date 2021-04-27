using System;
using UnityEngine;
using UnityEditor;
using UnityEngine.Localization.Settings;
using System.Linq;

[InitializeOnLoad]
public class Startup
{
    static Startup()
    {
        LocalizationSettings.InitializationOperation.Completed += op =>
        {
            var locale = LocalizationSettings.AvailableLocales.Locales.FirstOrDefault();
            LocalizationSettings.Instance.SetSelectedLocale(locale);            
        };        
    }
}

[Serializable]
public class Agent
{
    [SerializeField]
    private string _name = default;

    [SerializeField]
    private AgentData _presetData = default;

    public string Name => _name;
    public AgentData PresetData => _presetData;

    public void OnValidate()
    {
        if (_presetData != null)
        {
            _presetData.Name.GetLocalizedString().Completed += op => _name = op.Result;
        }
    }
}
