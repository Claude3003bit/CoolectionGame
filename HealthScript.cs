using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour
{
    public LosePopupController losePopupController;

    [Tooltip("This is the Max Health of the player")]
    public int maxHealth;
    [Tooltip("This is the current Health of the player")]
    public int currentHealth;
    public Text RemainingHealth; //For the Cuurent Health
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    //The function for taking damage
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if(currentHealth <= 0)
        {
            //We lose
        }
    }

    //The function when the player takes a health item
    public void Heal(int amount)
    {
        currentHealth += amount;
        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    void OnTriggerEnter(Collider ColH)
    {

        //If player collected Health, then destroy object
        if (ColH.CompareTag("Health"))
        {
            
            GetComponent<HealthScript>().Heal(1);
            Debug.Log("Health + 1, new value = "+ currentHealth);
        }
        else if (ColH.CompareTag("Hurt"))
        {
             GameObject audioHurt = GameObject.Find("AudioHurt");
        if (audioHurt != null)
        {
            AudioSource audioSource = audioHurt.GetComponent<AudioSource>();
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
            GetComponent<HealthScript>().TakeDamage(1);
            Debug.Log("Health - 1, new value = " + currentHealth);

            //Restart the level if the current health is zero
            if(currentHealth <= 0)
            {
                //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                if (losePopupController != null)
                {
                    losePopupController.ShowWinPopup();
                }
            }
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        //Update the Current Health
        if(RemainingHealth != null)
        {
            RemainingHealth.text = "Health :" + Mathf.Ceil(currentHealth).ToString();
        }
    }
}
