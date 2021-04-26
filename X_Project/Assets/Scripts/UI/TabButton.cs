using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TabButton : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private TabEventChannelSO _clickTabEvent = default;
    [SerializeField] private TabEventChannelSO _enterTabEvent = default;
    [SerializeField] private TabEventChannelSO _exitTabEvent = default;

    [SerializeField] private Image _background;
    [SerializeField] private Button _button;

    public Image Background => _background;
    public Button Button => _button;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (_clickTabEvent != null)
        {
            _clickTabEvent.RaiseEvent(this);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (_enterTabEvent != null)
        {
            _enterTabEvent.RaiseEvent(this);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (_exitTabEvent != null)
        {
            _exitTabEvent.RaiseEvent(this);
        }
    }
}
