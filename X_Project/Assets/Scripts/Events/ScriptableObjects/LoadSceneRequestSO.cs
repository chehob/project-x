using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// This class is used for scene loading events.
/// Takes an array of the scenes we want to load and a bool to specify if we want to show a loading screen.
/// </summary>
[CreateAssetMenu(menuName = "Events/Load Event Channel")]
public class LoadSceneRequestSO : EventChannelBaseSO
{
    public UnityAction<GameSceneSO[], bool> OnLoadingRequested;

    public void RaiseEvent(GameSceneSO[] scenesToLoad, bool showLoadingScreen = false)
    {
        if (OnLoadingRequested != null)
        {
            OnLoadingRequested.Invoke(scenesToLoad, showLoadingScreen);
        }
        else
        {
            Debug.LogWarning("A Scene loading was requested, but nobody picked it up. " +
                "Check why there is no SceneLoader already present, " +
                "and make sure it's listening on this Load Event channel.");
        }
    }
}