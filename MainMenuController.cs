using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public GameObject MainMenuPanel;
    public GameObject StartButton;
    public GameObject LevelsPanel;
    public GameObject LevelsButton;
    public GameObject AboutPanel;
    public GameObject AboutButton;
    public GameObject QuitButton;

    // Start is called before the first frame update
    void Start()
    {
        LevelsPanel.SetActive(false);
        AboutPanel.SetActive(false);
        Time.timeScale = 1f;

        // Add listener to button
        StartButton.GetComponent<Button>().onClick.AddListener(OnStart);
        LevelsButton.GetComponent<Button>().onClick.AddListener(ShowPopupLevel);
        AboutButton.GetComponent<Button>().onClick.AddListener(ShowPopupAbout);
        QuitButton.GetComponent<Button>().onClick.AddListener(OnQuit);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void ShowPopupLevel()
    {
        //Show the Popup Level Menu when you click on the button
        LevelsPanel.SetActive(true);
        MainMenuPanel.SetActive(false);

    }

    void ShowPopupAbout()
    {
        AboutPanel.SetActive(true);
        MainMenuPanel.SetActive(false);
    }

    void OnStart()
    {
        // Load the first level
        SceneManager.LoadScene("Level 1 test");
    }

    void OnQuit()
    {
        // Quit the game
        Application.Quit();
    }
}
