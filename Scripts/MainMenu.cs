using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string mainSceneName = "MainScene";
    public SceneFader sceneFader;

    public void StartGame()
    {

        sceneFader.FadeTo(mainSceneName);
    }
}
