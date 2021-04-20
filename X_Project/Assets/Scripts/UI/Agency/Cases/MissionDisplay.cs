using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization.Components;

public class MissionDisplay : MonoBehaviour
{
    private Mission _currentMission = default;

    [SerializeField] private LocalizeStringEvent _nameText;

    [SerializeField]
    private MissionEventChannelSO _missionClickEvent = default;

    public void Set(Mission mission)
    {
        _currentMission = mission;

        _nameText.StringReference = mission.Name;
    }

    public void OnMissionClick()
    {
        if (_missionClickEvent != null)
        {
            _missionClickEvent.RaiseEvent(_currentMission);
        }
    }
}
