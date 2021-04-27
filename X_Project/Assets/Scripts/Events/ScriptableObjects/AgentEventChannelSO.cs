using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Events/UI/Agent Event Channel")]
public class AgentEventChannelSO : ScriptableObject
{
    public UnityAction<Agent> OnEventRaised;
    public void RaiseEvent(Agent item)
    {
        if (OnEventRaised != null)
            OnEventRaised.Invoke(item);
    }
}