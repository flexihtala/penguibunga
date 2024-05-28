using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndToilet : MonoBehaviour
{
    private bool isTriggered;
    [SerializeField] private Animator KricoAnimator;
    [SerializeField] private Animator CagoAnimator;
    [SerializeField] private Animator EstriperAnimator;
    [SerializeField] private Animator KawazakiAnimator;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            isTriggered = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            isTriggered = false;
    }
    private void Update()
    {
        if (isTriggered && Input.GetKeyDown(KeyCode.E))
        {
            CagoAnimator.SetBool("IsGameOver", true);
            KricoAnimator.SetBool("IsGameOver", true);
            EstriperAnimator.SetBool("IsGameOver", true);
            KawazakiAnimator.SetBool("IsGameOver", true);
            //SceneManager.LoadScene("MainMenu");
        }
    }
}