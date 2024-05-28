using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class GlobalLightState : MonoBehaviour
{
    [SerializeField] private Light2D globalLight;

    public void TurnOffLight() 
        => globalLight.intensity = 0;
}