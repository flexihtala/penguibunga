using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// review(26.06.2024): Вроде как класс называется KeyboardGame, а по факту он лишь включает/выключает игру. Я бы назвал его KeyboardGameSwitcher
public class KeyboardGame : MonoBehaviour
{
    public GameObject game;
    private bool isTriggered;
    private InteractableObject interactableObject;

    private void Awake()
    {
        game.SetActive(false);
        interactableObject = GetComponent<InteractableObject>();
    }

    private void Update()
    {
        interactableObject.isInteractable = GameState.ActivePlayer.penguinName == PenguinNames.Kawazaki; // review(26.06.2024): стоило вынести Kawazaki в константы класса
        if (isTriggered && Input.GetKeyDown(KeyCode.E))
        {
            game.SetActive(true); // review(26.06.2024): Вроде как создали InteractableObject, но все равно дублируете код активации. Возможно, имело смысл в InteractableObject положить Action, который должен выполниться
            GameState.IsOpenKeyboardGame = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && other.GetComponent<Player>().penguinName == PenguinNames.Kawazaki) // review(26.06.2024): Повторение проверки. Имело смысл вынести в метод CanPlayKeyboardGame(Player player)
        {
            isTriggered = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isTriggered = false;
            game.SetActive(false);
            GameState.IsOpenKeyboardGame = false;
        }
    }
}
