using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathPlaneBehaviour : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            TimerManager.Instance.Gameover();
        }
    }
}
