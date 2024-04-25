using UnityEngine;

public class Spider : Entity
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        var unit = other.GetComponent<PlayerController>();
        if (unit && other.CompareTag("Player"))
        {
            unit.ReceiveDamage();
        }
    }
}