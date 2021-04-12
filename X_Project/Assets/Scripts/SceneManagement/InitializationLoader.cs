using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;

/// <summary>
/// This class is responsible for starting the game by loading the persistent managers scene 
/// and raising the event to load the Main Menu
/// </summary>
public class InitializationLoader : MonoBehaviour
{
    [Header("Persistent managers Scene")]
    [SerializeField] private GameSceneSO _persistentManagersScene = default;

    [Header("Loading settings")]
    [SerializeField] private GameSceneSO[] _sceneToLoad = default;

    [Header("Broadcasting on")]
    [SerializeField] private AssetReference _loadSceneRequest = default;

    // Start is called before the first frame update
    void Start()
    {
        // Waiting for SceneLoader to load
        _persistentManagersScene.sceneReference.LoadSceneAsync(LoadSceneMode.Additive, true).Completed += LoadEventChannel;
    }

    private void LoadEventChannel(AsyncOperationHandle<SceneInstance> obj)
    {
        // Waiting for LoadSceneRequest asset to load
        _loadSceneRequest.LoadAssetAsync<LoadSceneRequestSO>().Completed += LoadMainScreen;
    }

    private void LoadMainScreen(AsyncOperationHandle<LoadSceneRequestSO> obj)
    {
        // Request to load scenes
        LoadSceneRequestSO loadSceneRequest = (LoadSceneRequestSO)_loadSceneRequest.Asset;
        if (loadSceneRequest != null)
        {
            loadSceneRequest.RaiseEvent(_sceneToLoad);
        }

        // Unload the initialization scene
        // It is the only scene in BuildSettings, thus it has index 0
        SceneManager.UnloadSceneAsync(0);
    }
}
