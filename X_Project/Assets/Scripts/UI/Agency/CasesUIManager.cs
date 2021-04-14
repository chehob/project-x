using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CasesUIManager : MonoBehaviour
{
    [SerializeField]
    private Agency _currentAgency = default;

    [SerializeField]
    private CaseDisplay _casePrefab = default;

    [SerializeField]
    private MissionDisplay _missionPrefab = default;

    [SerializeField]
    private Transform _casesContentPanel;

    [SerializeField]
    private Transform _missionsContentPanel;

    private Dictionary<Case, CaseDisplay> _casesDisplayed =
            new Dictionary<Case, CaseDisplay>();

    private Dictionary<Mission, MissionDisplay> _missionsDisplayed =
            new Dictionary<Mission, MissionDisplay>();

    [SerializeField]
    private CaseEventChannelSO _caseClickEvent = default;

    public void OnEnable()
    {
        if(_caseClickEvent != null)
        {
            _caseClickEvent.OnEventRaised += OnCaseClick;
        }

        UpdateCaseDisplay();
    }

    public void OnDisable()
    {
        if (_caseClickEvent != null)
        {
            _caseClickEvent.OnEventRaised -= OnCaseClick;
        }

        //ClearCaseDisplay();
    }

    private void UpdateCaseDisplay()
    {
        ClearCaseDisplay();

        var cases = _currentAgency.Cases;
        foreach (var caseItem in cases)
        {
            CreateCaseDisplay(caseItem);
        }
    }

    private void ClearCaseDisplay()
    {
        foreach (var itemDisplayed in _casesDisplayed)
        {
            //var itemDisplay = itemDisplayed.Value;
            //itemDisplay.Button.onClick.RemoveListener(itemDisplay.ButtonAction);
            Destroy(itemDisplayed.Value.gameObject);
        }

        _casesDisplayed.Clear();
    }

    private void CreateCaseDisplay(Case item)
    {
        var obj = Instantiate(_casePrefab, _casesContentPanel);
        obj.Set(item);
        //obj.ButtonAction = () => { OnItemClick(item); };
        //obj.Button.onClick.AddListener(obj.ButtonAction);
        _casesDisplayed.Add(item, obj);
    }

    private void OnCaseClick(Case item)
    {
        UpdateMissionDisplay(item);
    }

    private void UpdateMissionDisplay(Case _case)
    {
        ClearMissionDisplay();

        var missions = _case.Missions;
        foreach (var missionItem in missions)
        {
            CreateMissionDisplay(missionItem);
        }
    }

    private void ClearMissionDisplay()
    {
        foreach (var itemDisplayed in _missionsDisplayed)
        {
            //var itemDisplay = itemDisplayed.Value;
            //itemDisplay.Button.onClick.RemoveListener(itemDisplay.ButtonAction);
            Destroy(itemDisplayed.Value.gameObject);
        }

        _missionsDisplayed.Clear();
    }

    private void CreateMissionDisplay(Mission item)
    {
        var obj = Instantiate(_missionPrefab, _missionsContentPanel);
        obj.Set(item);
        //obj.ButtonAction = () => { OnItemClick(item); };
        //obj.Button.onClick.AddListener(obj.ButtonAction);
        _missionsDisplayed.Add(item, obj);
    }
}
