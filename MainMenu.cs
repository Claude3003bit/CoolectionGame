using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject MainMenuPanel;
    public GameObject levelsWindow;

    void Start()
    {

        MainMenuPanel.SetActive(true);
        Time.timeScale = 1f;

    }

    public void StartGame()
    {
        SceneManager.LoadScene("Level 1 test");
    }

    public void OpenLevels()
    {
        levelsWindow.SetActive(true);
    }

    public void CloseLevels()
    {
        levelsWindow.SetActive(false);
    }

    public void OpenAbout()
    {
        // Code to open about window
    }

    public void QuitGame()
    {
        Application.Quit();
    }


}
