using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization.Components;

public class CaseDisplay : MonoBehaviour
{
    private Case _currentCase = default;

    [SerializeField] private LocalizeStringEvent _nameText;

    [SerializeField]
    private CaseEventChannelSO _caseClickEvent = default;

    public void Set(Case _case)
    {
        _currentCase = _case;

        _nameText.StringReference = _case.Name;
    }

    public void OnCaseClick()
    {
        if (_caseClickEvent != null)
        {
            _caseClickEvent.RaiseEvent(_currentCase);
        }
    }
}
