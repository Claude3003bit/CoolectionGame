using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AboutMenuController : MonoBehaviour
{
    public GameObject LeaveButton;
    public GameObject MainMenuPanel;
    public GameObject AboutPanel;
    // Start is called before the first frame update
    void Start()
    {
        LeaveButton.GetComponent<Button>().onClick.AddListener(onLeave);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void onLeave()
    {
        AboutPanel.SetActive(false);
        MainMenuPanel.SetActive(true);
    }
}
