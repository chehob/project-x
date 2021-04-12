using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [Header("Listening on")]
    [SerializeField] private LoadSceneRequestSO _loadSceneRequest = default;
    [SerializeField] private VoidEventChannelSO _gameExitRequest = default;

    [Header("Broadcasting on")]
    [SerializeField] private BoolEventChannelSO _toggleLoadingScreen = default;
    [SerializeField] private VoidEventChannelSO _onSceneReady = default;

    //Parameters coming from scene loading requests
    private GameSceneSO[] _scenesToLoad;
    private GameSceneSO[] _currentlyLoadedScenes = new GameSceneSO[] { };
    private bool _showLoadingScreen;

    private void OnEnable()
    {
        if (_loadSceneRequest != null)
        {
            _loadSceneRequest.OnLoadingRequested += LoadScene;
        }
        if(_gameExitRequest != null)
        {
            _gameExitRequest.OnEventRaised += ExitGame;
        }
    }

    private void OnDisable()
    {
        if (_loadSceneRequest != null)
        {
            _loadSceneRequest.OnLoadingRequested -= LoadScene;
        }
        if (_gameExitRequest != null)
        {
            _gameExitRequest.OnEventRaised -= ExitGame;
        }
    }

	private void LoadScene(GameSceneSO[] scenesToLoad, bool showLoadingScreen)
    {
        _scenesToLoad = scenesToLoad;
        _showLoadingScreen = showLoadingScreen;

        UnloadPreviousScenes();
        LoadNewScenes();
    }

    private void UnloadPreviousScenes()
    {
        for (int i = 0; i < _currentlyLoadedScenes.Length; i++)
        {
            _currentlyLoadedScenes[i].sceneReference.UnLoadScene();
        }
    }

    private void LoadNewScenes()
    {
        if (_showLoadingScreen && _toggleLoadingScreen != null)
        {
            _toggleLoadingScreen.RaiseEvent(true);
        }

        StartCoroutine(LoadingProcess());
    }

    private IEnumerator LoadingProcess()
    {
        AsyncOperationHandle<SceneInstance> firstSceneLoadingOperationHandle = default;
        for (int i = 0; i < _scenesToLoad.Length; i++)
        {
            AsyncOperationHandle<SceneInstance> loadingOperationHandle = _scenesToLoad[i].sceneReference.LoadSceneAsync(LoadSceneMode.Additive, true, 0);
            if (i == 0)
            {
                firstSceneLoadingOperationHandle = loadingOperationHandle;
            }

            bool done = loadingOperationHandle.Status == AsyncOperationStatus.Succeeded;
            while (!done)
            {
                done = loadingOperationHandle.Status == AsyncOperationStatus.Succeeded;
                yield return null;
            }
        }

        //Save loaded scenes (to be unloaded at next load request)
        if (_scenesToLoad.Length > 0)
        {
            _currentlyLoadedScenes = _scenesToLoad;
            SetActiveScene(firstSceneLoadingOperationHandle.Result);
        }

        if (_showLoadingScreen && _toggleLoadingScreen != null)
        {
            _toggleLoadingScreen.RaiseEvent(false);
        }
    }

    /// <summary>
	/// This function is called when all the scenes have been loaded
	/// </summary>
	private void SetActiveScene(SceneInstance sceneInstance)
    {
        Scene s = sceneInstance.Scene;
        SceneManager.SetActiveScene(s);

        LightProbes.TetrahedralizeAsync();

        if (_onSceneReady != null)
        {
            _onSceneReady.RaiseEvent();
        }
    }

    private void ExitGame()
    {
        Application.Quit();
        Debug.Log("Exit!");
    }
}
