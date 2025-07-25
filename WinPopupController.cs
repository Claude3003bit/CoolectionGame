using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinPopupController : MonoBehaviour
{
    public GameObject winPopup;
    public Button nextLevelButton;
    public Button mainMenuButton;
    public GameObject pauseMenuCanvas; // Reference to the PauseMenuCanvas
    public AudioSource backgroundMusic; // Reference to the AudioSource

    void Start()
    {
        // Initially hide the popup
        winPopup.SetActive(false);
        Time.timeScale = 1f;

        // Add listeners to the buttons
        nextLevelButton.onClick.AddListener(OnNextLevel);
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
        // Show the popup
        winPopup.SetActive(true);
        

        // Make the cursor visible and unlock it
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0f; //Pause the game
                             // Pause the background music
        if (backgroundMusic != null)
        {
            backgroundMusic.Pause();
        }
    }

    void OnNextLevel()
    {
        // Load the next level
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    void OnMainMenu()
    {
        // Load the main menu
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
        
    }
}
