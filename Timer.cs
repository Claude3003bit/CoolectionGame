using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float MaxTime = 210f;
    public LosePopupController losePopupController;
    public Text timerText;

    [SerializeField] private float CountDown = 0;

    void Start()
    {
        CountDown = MaxTime;
    }

    void Update()
    {
        // Reduce time
        CountDown -= Time.deltaTime;

        //Update the timer text
        if(timerText != null)
        {
            timerText.text = "Time: " + Mathf.Ceil(CountDown).ToString();
        }

        // Restart level if time runs out
        if (CountDown <= 0)
        {
            // Reset coin count
            CoinScript.CoinCount = 0;
            if (losePopupController != null)
            {
                losePopupController.ShowWinPopup();
            }
        }
    }
}
