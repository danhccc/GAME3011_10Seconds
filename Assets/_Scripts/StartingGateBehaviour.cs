using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingGateBehaviour : MonoBehaviour
{
    private Animator animator;
    public GameObject interactUI;
    public GameObject invisibleWall;
    private bool playerNearby;

    void Start()
    {
        animator = GetComponent<Animator>();
        //invisibleWall = GetComponentInChildren<GameObject>(invisibleWall);
    }

    void Update()
    {
        if (TimerManager.Instance.gameStarted && playerNearby)
        {
            animator.SetBool("player_nearby", true);
            invisibleWall.SetActive(false);
        }
        else
        {
            animator.SetBool("player_nearby", false);
            invisibleWall.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            interactUI.SetActive(true);
            playerNearby = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            interactUI.SetActive(false);
            playerNearby = false;
        }
    }
}
