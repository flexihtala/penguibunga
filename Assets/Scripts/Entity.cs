using UnityEngine;

public class Entity : MonoBehaviour
{
    public virtual void ReceiveDamage()
    {
        Die();
    }

    public virtual void Die()
    {
        Destroy(gameObject);
    }
}