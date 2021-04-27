using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MissionLoadout
{
    public List<Agent> AssignedAgents;
    public Mission Mission;
}

public class MissionLoadoutUIManager : MonoBehaviour
{
    [SerializeField] private Agency _currentAgency = default;
    private Mission _currentMission = default;

    [SerializeField] private AgentDisplay _agentPrefab = default;
    [SerializeField] private Transform _agentsContentPanel = default;    

    private Dictionary<Agent, AgentDisplay> _agentsDisplayed =
            new Dictionary<Agent, AgentDisplay>();    

    [SerializeField] private AgentEventChannelSO _agentClickEvent = default;
    [SerializeField] private MissionLoadoutEventChannelSO _missionStartRequest = default;

    public void Set(Mission mission)
    {
        _currentMission = mission;
    }

    public void OnEnable()
    {
        if (_agentClickEvent != null)
        {
            _agentClickEvent.OnEventRaised += OnAgentClick;
        }

        UpdateAgentDisplay();
    }

    public void OnDisable()
    {
        if (_agentClickEvent != null)
        {
            _agentClickEvent.OnEventRaised -= OnAgentClick;
        }
    }

    private void UpdateAgentDisplay()
    {
        ClearAgentDisplay();

        var agents = _currentAgency.Agents;
        foreach (var agentItem in agents)
        {
            CreateAgentDisplay(agentItem);
        }
    }

    private void ClearAgentDisplay()
    {
        foreach (var itemDisplayed in _agentsDisplayed)
        {
            Destroy(itemDisplayed.Value.gameObject);
        }

        _agentsDisplayed.Clear();
    }

    private void CreateAgentDisplay(Agent item)
    {
        var obj = Instantiate(_agentPrefab, _agentsContentPanel);
        obj.Set(item);
        _agentsDisplayed.Add(item, obj);
    }

    private void OnAgentClick(Agent item)
    {
        
    }

    public void OnAcceptButtonClick()
    {
        if(_missionStartRequest != null)
        {
            MissionLoadout loadout = new MissionLoadout
            {
                Mission = _currentMission,
                AssignedAgents = _agentsDisplayed.Where(ad => ad.Value.IsSelected).Select(ad => ad.Key).ToList()
            };
            _missionStartRequest.RaiseEvent(loadout);
        }        
    }
}
