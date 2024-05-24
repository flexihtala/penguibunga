using UnityEngine;

public class PinterSpecifics : TriggerPrinterText
{
    private bool isTriggered;
    public bool forKavazaki;
    public bool forKrico;
    public bool forEstriper;
    public bool forCago;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
            return;
        var penguinName = other.gameObject.GetComponent<Player>().penguinName;
        if (!isTriggered 
            && ((penguinName == PenguinNames.Cago && forCago) 
                || (penguinName == PenguinNames.Kawazaki && forKavazaki)
                || (penguinName == PenguinNames.Krico && forKrico)
                || (penguinName == PenguinNames.Estriper && forEstriper)))
        {
            isTriggered = true;
            StartCoroutine(TypeLine());
        }
    }
}
