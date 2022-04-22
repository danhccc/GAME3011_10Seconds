using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirContainerBehaviour : MonoBehaviour
{
    public float rotateSpeed;

    private bool isPickedup;
    private AudioSource audioSource;
    // Start is called before the first frame update

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        isPickedup = false;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0f, rotateSpeed, 0f) * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (isPickedup) return;
            TimerManager.Instance.timer += TimerManager.Instance.maxTime;
            TimerManager.Instance.supplyPoint += 100;
            TimerManager.Instance.supplyPointText.text = TimerManager.Instance.supplyPoint.ToString();
            Debug.Log("Play picked up sound effect");
            audioSource.Play();
            //set ispickedup bool here
            isPickedup = true;
            StartCoroutine(DestoryItem());
        }
    }

    IEnumerator DestoryItem()
    {
        yield return new WaitForSeconds(.2f);
        Destroy(gameObject);
    }
}
