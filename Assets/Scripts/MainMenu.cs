using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Animator animator;
    public void PlayGame()
    {
        //StartCoroutine(WaitTime());
        SceneManager.LoadScene("Game");
    }
    
    private IEnumerator WaitTime()
    {
        animator.SetBool("IsStartAnimation", true);
        yield return new WaitForSeconds(10);
    }

    public void ExitGame()
    {
        Debug.Log("Игра закрылась");
        Application.Quit();
    }
}
