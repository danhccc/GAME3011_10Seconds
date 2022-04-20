using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirContainerBehaviour : MonoBehaviour
{
    public float rotateSpeed;
    // Start is called before the first frame update
    void Start()
    {

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
            TimerManager.Instance.timer += TimerManager.Instance.maxTime;
            Destroy(gameObject);
        }
    }
}
