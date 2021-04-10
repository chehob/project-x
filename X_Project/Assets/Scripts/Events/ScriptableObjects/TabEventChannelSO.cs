using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Events/UI/Tab Event Channel")]
public class TabEventChannelSO : ScriptableObject
{
    public UnityAction<TabButton> OnEventRaised;
    public void RaiseEvent(TabButton item)
    {
        if (OnEventRaised != null)
            OnEventRaised.Invoke(item);
    }
}