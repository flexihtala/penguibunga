using UnityEngine;

public class Killer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        var unit = other.GetComponent<Player>();
        if (unit && other.CompareTag("Player")) 
            unit.Die(unit);
    }
}