using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionManager : MonoBehaviour
{
    [SerializeField] private MissionLoadoutEventChannelSO _missionStartRequest = default;

    void OnEnable()
    {
        if (_missionStartRequest != null)
        {
            _missionStartRequest.OnEventRaised += OnMissionStartRequested;
        }
    }

    void OnDisable()
    {
        if (_missionStartRequest != null)
        {
            _missionStartRequest.OnEventRaised -= OnMissionStartRequested;
        }
    }

    void OnMissionStartRequested(MissionLoadout loadout)
    {

    }
}
