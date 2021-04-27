using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Events/Gameplay/MissionLoadout Event Channel")]
public class MissionLoadoutEventChannelSO : ScriptableObject
{
    public UnityAction<MissionLoadout> OnEventRaised;
    public void RaiseEvent(MissionLoadout item)
    {
        if (OnEventRaised != null)
            OnEventRaised.Invoke(item);
    }
}