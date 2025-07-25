using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LevelMenuController : MonoBehaviour
{
    public GameObject LeaveButton;
    public GameObject MainMenuPanel;
    public GameObject LevelPanel;
    public GameObject Level1Button;
    public GameObject Level2Button;
    public GameObject Level3Button;
    public GameObject Level4Button;
    // Start is called before the first frame update
    void Start()
    {
        LeaveButton.GetComponent<Button>().onClick.AddListener(onLeave);
        Level1Button.GetComponent<Button>().onClick.AddListener(onLevel1);
        Level2Button.GetComponent<Button>().onClick.AddListener(onLevel2);
        Level3Button.GetComponent<Button>().onClick.AddListener(onLevel3);
        Level4Button.GetComponent<Button>().onClick.AddListener(onLevel4);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void onLevel1()
    {
        SceneManager.LoadScene("Level 1 test");
    }

    void onLevel2()
    {
        SceneManager.LoadScene("Level 2");
    }

    void onLevel3()
    {
        SceneManager.LoadScene("Level 3");
    }

    void onLevel4()
    {
        SceneManager.LoadScene("Level 4");
    }
    void onLeave()
    {
        LevelPanel.SetActive(false);
        MainMenuPanel.SetActive(true);
    }
}
