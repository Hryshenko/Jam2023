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
    }

    public void ExitGame()
    {
        AudioManager.Instance.PlayClick();
        Application.Quit();
    }
}
