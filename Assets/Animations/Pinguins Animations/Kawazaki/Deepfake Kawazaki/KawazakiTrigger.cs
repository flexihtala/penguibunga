using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KawazakiTrigger : MonoBehaviour
{
    [SerializeField] private Animator KawazakiAnimator;
    
    public void TurnOffWalk()
    {
        KawazakiAnimator.SetBool("IsActiveMove", false);
    }
}
