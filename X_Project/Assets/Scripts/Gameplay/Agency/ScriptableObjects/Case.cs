using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;

[CreateAssetMenu(fileName = "Case", menuName = "Agency/Case", order = 51)]
public class Case : ScriptableObject
{
    [SerializeField]
    private List<Mission> _missions = default;

    [SerializeField]
    private LocalizedString _name = default;

    public List<Mission> Missions => _missions;
    public LocalizedString Name => _name;
}
