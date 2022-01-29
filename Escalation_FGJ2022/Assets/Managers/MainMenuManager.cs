using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    public GameObject MainMenu;

    // Start is called before the first frame update
    void Start()
    {
        MainMenuButton();
    }

    public void PlayNowButton()
    {
        // Play Now Button has been pressed, here you can initialize your game (For example Load a Scene called GameLevel etc.)
        UnityEngine.SceneManagement.SceneManager.LoadScene("Battle");
    }

    public void MainMenuButton()
    {
        // Show Main Menu
        MainMenu.SetActive(true);
    }

    public void QuitButton()
    {
        // Quit Game
        Application.Quit();
    }
}