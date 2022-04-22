using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountDownManager : MonoBehaviour
{
    private AudioSource audioSource;
    
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (TimerManager.Instance.timer <= 5.0f) 
        {
            if (TimerManager.Instance.isPlayed == false)
            {
                Debug.Log("5 second left warning");
                audioSource.Play();
                TimerManager.Instance.isPlayed = true;
            }
        }
    }

   
    
}
