using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject NameMenu;
    
  

    private void Start()
    {
       NameMenu.SetActive(false);
    }


    public void PlayGame()
    {
        mainMenu.SetActive(false);
        NameMenu.SetActive(true);
    }


    public void BackToMainMenu()
    {
        NameMenu.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }


}


