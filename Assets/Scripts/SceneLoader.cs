using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cysharp.Threading.Tasks;
using System;

public class SceneLoader : MonoBehaviour
{
    private const float DELAY_TO_GAME_SCENE = 2f;
    private const int GAME_SCENE_INDEX = 1;

    private bool _canLoadGameScene;
    private void Start()
    {
        _canLoadGameScene = true;
        LoadGameScene();
    }

    private async void LoadGameScene()
    {
        await UniTask.Delay(TimeSpan.FromSeconds(DELAY_TO_GAME_SCENE));
        await UniTask.WaitUntil(() => _canLoadGameScene == true);

        SceneManager.LoadScene(GAME_SCENE_INDEX);
    }
}
