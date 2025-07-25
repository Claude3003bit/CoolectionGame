using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LosePopupController : MonoBehaviour
{
    public GameObject LosePopup;
    public Button RetryButton;
    public Button mainMenuButton;
    public GameObject pauseMenuCanvas;
    public GameObject WinMenu;   // Reference to the PauseMenuCanvas
    public AudioSource backgroundMusic; // Reference to the AudioSource

    void Start()
    {
        // Initially hide the popup
        LosePopup.SetActive(false);
        Time.timeScale = 1f;

        // Add listeners to the buttons
        RetryButton.onClick.AddListener(RetryLevel);
        mainMenuButton.onClick.AddListener(OnMainMenu);
        if (backgroundMusic != null)
        {
            backgroundMusic.UnPause();
        }
    }

    public void ShowWinPopup()
    {
        //Hide the pause menu if it's active
        if(pauseMenuCanvas != null)
        {
            pauseMenuCanvas.SetActive(false);
        } 
        if (WinMenu != null)
        {
            WinMenu.SetActive(false);
        }
        //Play the Gameover sound
        GameObject audioLose = GameObject.Find("AudioLose");
        if (audioLose != null)
        {
            AudioSource audioSource = audioLose.GetComponent<AudioSource>();
            if (audioSource != null)
            {
                Debug.Log("Playing winning audio.");
                audioSource.Play();
            }
            else
            {
                Debug.Log("AudioSource component not found on Audio Winning GameObject.");
            }
        }
        // Show the popup
        LosePopup.SetActive(true);
        Time.timeScale = 0f; //Pause the game

        // Make the cursor visible and unlock it
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        if (backgroundMusic != null)
        {
            backgroundMusic.Pause();
        }
    }

    void RetryLevel()
    {
        // Load the next level
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }

    void OnMainMenu()
    {
        // Load the main menu
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1f;
    }
}

