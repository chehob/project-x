using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization.Components;

public class MissionDisplay : MonoBehaviour
{
    [HideInInspector] public Mission _currentMission = default;

    [SerializeField] private LocalizeStringEvent _nameText;    

    public void Set(Mission mission)
    {
        _currentMission = mission;

        _nameText.StringReference = mission.Name;
    }
}
