using System.Collections;
using UnityEngine;

public class BreakBars : MonoBehaviour
{
    private bool isTriggered;
    [SerializeField] private GameObject brokenBars;
    [SerializeField] private GameObject wholeBars;
    private InteractableObject interactableObject;

    private void Start()
    {
        interactableObject = wholeBars.GetComponent<InteractableObject>();
    }

    void Update()
    {
        if (GameState.IsOverGameKeyboard
            && GameState.HaveCrowbar)
            interactableObject.isInteractable = true;
        if (GameState.IsOverGameKeyboard
            && GameState.HaveCrowbar
            && isTriggered
            && Input.GetKeyDown(KeyCode.E))
        {
            brokenBars.SetActive(true);
            wholeBars.SetActive(false);
            StartCoroutine(Wait(0.5f));
        }
    }
    
    private IEnumerator Wait(float time)
    {
        yield return new WaitForSeconds(time);
        GameState.CanOpenToiletDoor = true;
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
            return;
        isTriggered = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            isTriggered = false;
    }
}
