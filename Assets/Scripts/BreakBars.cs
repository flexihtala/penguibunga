using System.Collections;
using UnityEngine;

public class BreakBars : MonoBehaviour
{
    private bool isTriggered;
    [SerializeField] private GameObject brokenBars;
    [SerializeField] private GameObject wholeBars;
    private InteractableObject interactableObject;
    private AudioManager audioManager;

    private void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
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
            && Input.GetKeyDown(KeyCode.E)
            && !GameState.CanOpenToiletDoor)
        {
            audioManager.PlaySFX(audioManager.brokenBars);
            brokenBars.SetActive(true);
            wholeBars.SetActive(false);
            StartCoroutine(Wait(0.5f));
        }
    }
    
    private IEnumerator Wait(float time)
    {
        yield return new WaitForSeconds(time);
        GameState.CanOpenToiletDoor = true;
        GameState.ChecksBool.Add(DialogFlagEnum.BrokenBars);
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
