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
    [SerializeField] private CanvasGroup EndCanvas;
    [SerializeField] private GameObject buttonHelp;
    [SerializeField] private GameObject inventory;
    private bool gameOver = false;

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
        if (gameOver)
            return;

        if (!isTriggered || !Input.GetKeyDown(KeyCode.E)) return;

        gameOver = true;
        buttonHelp.SetActive(false);
        inventory.SetActive(false);

        GameState.ActivePlayer.isActive = false;

        // review(27.06.2024): Я бы создал дикт PenguinNames -> Animator и упростил логику
        if (GameState.ActivePlayer.penguinName != PenguinNames.Cago)
            CagoAnimator.SetBool("IsGameOver", true);

        if (GameState.ActivePlayer.penguinName != PenguinNames.Krico)
            KricoAnimator.SetBool("IsGameOver", true);

        if (GameState.ActivePlayer.penguinName != PenguinNames.Estriper)
            EstriperAnimator.SetBool("IsGameOver", true);

        if (GameState.ActivePlayer.penguinName != PenguinNames.Kawazaki)
            KawazakiAnimator.SetBool("IsGameOver", true);

        StartCoroutine(WaitTime());
    }

    private IEnumerator WaitTime()
    {
        GameState.ChecksBool.Add(DialogFlagEnum.End);
        while (Math.Abs(EndCanvas.alpha - 1) >= 1e-9) // review(27.06.2024): Как будто не хватает extension-метода static bool IsEqualTo(this float number, float other, float accuracy = 1e-6)
        {
            EndCanvas.alpha += 0.005f;
            yield return null;
        }
        yield return new WaitForSeconds(10f);
        SceneManager.LoadScene("MainMenu");
    }
}