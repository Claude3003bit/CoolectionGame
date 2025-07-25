using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinScript : MonoBehaviour
{
    public static int CoinCount = 0;
    public WinPopupController winPopupController;
    public Text RemainingCoinsText;

    void OnTriggerEnter(Collider Col)
    {
        if (Col.CompareTag("Player"))
        {
            GameObject audioCoin = GameObject.Find("AudioCoin");
            if(audioCoin != null)
            {
                AudioSource audioC = audioCoin.GetComponent<AudioSource>();
                if(audioC != null)
                {
                    Debug.Log("playing coin sound");
                    audioC.Play();
                }
            }
            Destroy(gameObject);
        }
        Debug.Log("Entered Collider");
    }

    void Start()
    {
        Debug.Log("Object Created");
        ++CoinScript.CoinCount;
    }

    void OnDestroy()
    {
        --CoinScript.CoinCount;

        if (CoinScript.CoinCount <= 0)
        {
            Debug.Log("Coin count is zero or less. Destroying LevelTimer and playing fireworks and audio.");

            GameObject Timer = GameObject.Find("LevelTimer");
            Destroy(Timer);

            GameObject[] FireworkSystems = GameObject.FindGameObjectsWithTag("Fireworks");
            if (FireworkSystems.Length > 0)
            {
                foreach (GameObject GO in FireworkSystems)
                {
                    GO.GetComponent<ParticleSystem>().Play();
                    Time.timeScale = 0f; //Pause the game
                }
            }

            GameObject audioWinning = GameObject.Find("AudioWInning");
            if (audioWinning != null)
            {
                AudioSource audioSource = audioWinning.GetComponent<AudioSource>();
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
            else
            {
                Debug.Log("Audio Winning GameObject not found.");
            }

            // Show the win popup
            if (winPopupController != null)
            {
                winPopupController.ShowWinPopup();
            }
        }
    }

    void Update()
    {
        //Update the remaining Coins
        if(RemainingCoinsText != null)
          {
            RemainingCoinsText.text = "Remaining: " + Mathf.Ceil(CoinScript.CoinCount).ToString();
        }
    }
}
