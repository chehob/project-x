using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [Header("Agency Screen Events")]
    [SerializeField] private VoidEventChannelSO _openAgencyScreenEvent = default;
    [SerializeField] private VoidEventChannelSO _closeAgencyScreenEvent = default;

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

    }

    private void Start()
    {
    }

    [SerializeField]
    private AgencyUIManager agencyPanel = default;

    void OpenAgencyScreen()
    {
        agencyPanel.gameObject.SetActive(true);

        //agencyPanel.FillInventory();
    }

    public void CloseAgencyScreen()
    {
        agencyPanel.gameObject.SetActive(false);
    }
}
