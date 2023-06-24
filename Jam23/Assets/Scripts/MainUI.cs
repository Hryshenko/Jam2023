using UnityEngine;
using Assets.Scripts;

public class MainUI : MonoBehaviour
{
    public static MainUI Instance;

    public GameObject MainMenu;
    public GameObject FailFinish;
    public GameObject SuccessFinish;
    public GameObject GameHud;

    public GameObject UICamera;

    private void Awake()
    {
        FailFinish.SetActive(false);
        SuccessFinish.SetActive(false);
    }

    public void StartGame()
    {
        MainMenu.SetActive(false);
        FailFinish.SetActive(false);
        SuccessFinish.SetActive(false);
        UICamera.SetActive(false);
        GameHud.SetActive(true);

        MainController.Instance.StartGame();
    }

    public void FinishGame(bool success)
    {
        if (success)
            SuccessFinish.SetActive(true);
        else
            FailFinish.SetActive(true);

        UICamera.SetActive(true);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
