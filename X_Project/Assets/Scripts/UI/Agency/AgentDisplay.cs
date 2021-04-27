using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization.Components;
using TMPro;
using UnityEngine.UI;

public class AgentDisplay : MonoBehaviour
{
    private Agent _currentAgent = default;

    public bool IsSelected { get; private set; } = false;

    [SerializeField] private TextMeshProUGUI _nameText;
    [SerializeField] private Image _background;
    [SerializeField] private Color _idleColor;
    [SerializeField] private Color _selectedColor;

    [SerializeField] private AgentEventChannelSO _agentClickEvent = default;

    public void Set(Agent _agent)
    {
        _currentAgent = _agent;

        _nameText.text = _agent.Name;
    }

    public void OnAgentClick()
    {
        IsSelected = !IsSelected;
        _background.color = IsSelected ? _selectedColor : _idleColor;

        if (_agentClickEvent != null)
        {
            _agentClickEvent.RaiseEvent(_currentAgent);
        }
    }
}
