using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Events/UI/Case Event Channel")]
public class CaseEventChannelSO : ScriptableObject
{
    public UnityAction<Case> OnEventRaised;
    public void RaiseEvent(Case item)
    {
        if (OnEventRaised != null)
            OnEventRaised.Invoke(item);
    }
}
