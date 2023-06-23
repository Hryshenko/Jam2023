using UnityEngine;
using Assets.Scripts;

public class MainUI : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject FailFinish;
    public GameObject SuccessFinish;

    public void StartGame()
    {
        MainMenu.SetActive(false);
        AudioManager.Instance.PlayClick();
        //StartGame
        Debug.LogError("StartGame");
    }

    public void ExitGame()
    {
        Debug.LogError("ExitGame");
        AudioManager.Instance.PlayClick();
        Application.Quit();
    }
}
