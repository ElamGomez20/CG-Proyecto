using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject NameMenu;
    public GameObject settingsMenu;
  

    private void Start()
    {
       NameMenu.SetActive(false);
       settingsMenu.SetActive(false);
    }


    public void PlayGame()
    {
        mainMenu.SetActive(false);
        NameMenu.SetActive(true);
    }

    public void OpenSettings()
    {
        mainMenu.SetActive(false);
        settingsMenu.SetActive(true);
    }

    public void BackToMainMenu()
    {
        settingsMenu.SetActive(false);
        NameMenu.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }


}


