using System;
using UnityEngine;
using UnityEngine.UI;

// review(24.05.2024): Название класса не соответствует названию файла
public class ChangeImage : MonoBehaviour
{
    [Header("Image")] [SerializeField] private Image image;

    [Header("Start sprite")] [SerializeField]
    private Sprite spriteToStart;

    [Header("End sprite")] [SerializeField] 
    private Sprite spriteToEnd;

    private void Update()
    {
        if (!Input.GetKeyDown(KeyCode.A)) return;
        Debug.Log("asdjlaksjdla");
        image.sprite = spriteToEnd;
        image.sprite = spriteToStart;
    }
}