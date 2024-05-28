using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KricoTrigger : MonoBehaviour
{
    [SerializeField] private Animator KricoAnimator;
    
    public void TurnOffWalk()
    {
        KricoAnimator.SetBool("IsActiveMove", false);
    }
}
