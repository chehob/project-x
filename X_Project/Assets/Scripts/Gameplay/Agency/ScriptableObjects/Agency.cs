using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization.Settings;

[CreateAssetMenu(fileName = "Agency", menuName = "Agency/Agency", order = 51)]
public class Agency : ScriptableObject
{
    [SerializeField]
    private List<Case> _cases = default;
    [SerializeField]
    private List<Agent> _agents = default;

    public List<Case> Cases => _cases;
    public List<Agent> Agents => _agents;

    private void OnEnable()
    {
        LocalizationSettings.Instance.OnSelectedLocaleChanged += loc => { OnValidate(); };
    }

    private void OnDisable()
    {
        LocalizationSettings.Instance.OnSelectedLocaleChanged -= loc => { OnValidate(); };
    }

    void OnValidate()
    {
        foreach (Agent agent in _agents)
        {
            agent.OnValidate();
        }
    }
}
