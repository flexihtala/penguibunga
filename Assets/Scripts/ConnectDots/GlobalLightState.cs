using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class GlobalLightState : MonoBehaviour
{
    [SerializeField] private Light2D globalLight;

    public void TurnOffLight() // review(17.06.2024): Метод не используется, можно удалить
        => globalLight.intensity = 0;
}