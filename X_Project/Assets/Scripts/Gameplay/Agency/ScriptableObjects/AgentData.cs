using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;

[CreateAssetMenu(fileName = "NewAgent", menuName = "Agency/Agent", order = 51)]
public class AgentData : ScriptableObject
{
    [SerializeField]
    private LocalizedString _name = default;

    public LocalizedString Name => _name;
}
