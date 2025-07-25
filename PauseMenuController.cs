using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenuController : MonoBehaviour
{
    public GameObject pauseMenuPanel;
    public Button continueButton;
    public Button restartButton;
    public Button mainMenuButton;
    public Timer timer; //Reference to the Timer script
    public AudioSource backgroundMusic; // Reference to the AudioSource

    private bool isPaused = false; // The game is paused true or false

    // Start is called before the first frame update
    void Start()
    {
        //Initially hide the pause menu
        pauseMenuPanel.SetActive(false);
        continueButton.onClick.AddListener(OnContinue);
        restartButton.onClick.AddListener(OnRestart);
        mainMenuButton.onClick.AddListener(OnMainMenu);
    }

    // Update is called once per frame
    void Update()
    {
        //Toggle pause menu on pressing the Escape key
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    void PauseGame()
    {
        pauseMenuPanel.SetActive(true);
        Time.timeScale = 0f; //Pause the game
        isPaused = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        //Pause the Timer
        if(timer != null)
        {
            timer.enabled = false;
        }
        // Pause the background music
        if (backgroundMusic != null)
        {
            backgroundMusic.Pause();
        }
    }

    void ResumeGame()
    {
        pauseMenuPanel.SetActive(false);
        Time.timeScale = 1f; //Resume the game
        isPaused = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        //Resume the timer
        if(timer != null)
        {
            timer.enabled = true;
        }
        // Resume the background music
        if (backgroundMusic != null)
        {
            backgroundMusic.UnPause();
        }
    }

    void OnContinue()
    {
        ResumeGame();
    }

    void OnRestart()
    {
        Time.timeScale = 1f; //Ensure the game is running at normal speed

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);//Reload the current scene
    }

    void OnMainMenu()
    {
        Time.timeScale = 1f; //Ensure the game is running at normal speed
        SceneManager.LoadScene("MainMenu");
    }
}
