using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemsDisappearing : MonoBehaviour
{
    void OnTriggerEnter(Collider Col)
    {

        //If player collected coin, then destroy object
        if (Col.CompareTag("Player"))
        {
            GameObject audioCollect = GameObject.Find("AudioHeal");
            if (audioCollect != null)
            {
                AudioSource audioSource = audioCollect.GetComponent<AudioSource>();
                if (audioSource != null)
                {
                    Debug.Log("Playing Collecting audio.");
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
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
