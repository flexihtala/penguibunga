using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CagoTrigger : MonoBehaviour
{
    [SerializeField] private Animator CagoAnimator;
    
    public void TurnOffWalk()
    {
        CagoAnimator.SetBool("IsActiveMove", false);
    }
}
