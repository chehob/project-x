using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Agency", menuName = "Agency/Agency", order = 51)]
public class Agency : ScriptableObject
{
    [SerializeField]
    private List<Case> _cases = default;
    [SerializeField]
    private List<Agent> _agents = default;

    public List<Case> Cases => _cases;
    public List<Agent> Agents => _agents;

    void OnValidate()
    {
        foreach(Agent agent in _agents)
        {
            agent.OnValidate();
        }
    }
}
