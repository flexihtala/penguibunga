using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstriperTrigger : MonoBehaviour
{
    [SerializeField] private Animator EstriperAnimator;
    
    public void TurnOffWalk()
    {
        EstriperAnimator.SetBool("IsActiveMove", false);
    }
}
