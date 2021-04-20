using System;
using UnityEngine;

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
        if(_presetData != null)
        {
            _presetData.Name.GetLocalizedString().Completed += op => _name = op.Result;
        }
    }
}
