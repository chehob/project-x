using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [Header("Agency Screen Events")]
    [SerializeField] private VoidEventChannelSO _openAgencyScreenEvent = default;
    [SerializeField] private VoidEventChannelSO _closeAgencyScreenEvent = default;

    [SerializeField] private MissionEventChannelSO _missionLoadoutRequest = default;

    private void OnEnable()
    {
        //Check if the event exists to avoid errors
        if (_openAgencyScreenEvent != null)
        {
            _openAgencyScreenEvent.OnEventRaised += OpenAgencyScreen;
        }
        if (_closeAgencyScreenEvent != null)
        {
            _closeAgencyScreenEvent.OnEventRaised += CloseAgencyScreen;
        }
        if (_missionLoadoutRequest != null)
        {
            _missionLoadoutRequest.OnEventRaised += OpenMissionLoadoutScreen;
        }
    }

    private void Start()
    {
        agencyPanel.gameObject.SetActive(true);
        missionLoadoutPanel.gameObject.SetActive(false);
    }

    [SerializeField] private AgencyUIManager agencyPanel = default;
    [SerializeField] private MissionLoadoutUIManager missionLoadoutPanel = default;

    void OpenAgencyScreen()
    {
        agencyPanel.gameObject.SetActive(true);
    }

    public void CloseAgencyScreen()
    {
        agencyPanel.gameObject.SetActive(false);
    }

    void OpenMissionLoadoutScreen(Mission mission)
    {
        agencyPanel.gameObject.SetActive(false);
        missionLoadoutPanel.gameObject.SetActive(true);
        missionLoadoutPanel.Set(mission);
    }
}
