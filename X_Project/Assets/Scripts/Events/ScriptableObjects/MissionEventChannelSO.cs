using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Events/UI/Mission Event Channel")]
public class MissionEventChannelSO : ScriptableObject
{
    public UnityAction<Mission> OnEventRaised;
    public void RaiseEvent(Mission item)
    {
        if (OnEventRaised != null)
            OnEventRaised.Invoke(item);
    }
}