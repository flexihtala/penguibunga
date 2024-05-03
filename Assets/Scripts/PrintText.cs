using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

using UnityEngine.UIElements;

public class PrintText : MonoBehaviour
{
    public TextMeshProUGUI text;
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("aaa");
        if (other.CompareTag("Player"))
        {
            Debug.Log("BBB");
            text.text = "Ммм, старая куртка деда, села как влитая";
            text.text = "";
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
