using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    [SerializeField] private LoadSceneRequestSO _onPlayButtonPress = default;
    [SerializeField] private GameSceneSO[] _scenesToLoad = default;
    [SerializeField] private bool _showLoadScreen = default;

    private bool _hasSaveData = false;

    private void Start()
    {
        //_hasSaveData = saveSystem.LoadSaveDataFromDisk();
        //
        //if (_hasSaveData)
        //{
        //    startText.text = "Continue";
        //    resetSaveDataButton.gameObject.SetActive(true);
        //}
        //else
        //{
        //    resetSaveDataButton.gameObject.SetActive(false);
        //}
    }

    public void OnPlayButtonPress()
    {
        if (!_hasSaveData)
        {
            //saveSystem.WriteEmptySaveFile();
            //Start new game
            _onPlayButtonPress.RaiseEvent(_scenesToLoad, _showLoadScreen);
        }
        else
        {
            //Load Game
            //StartCoroutine(LoadSaveGame());
        }
    }
}
