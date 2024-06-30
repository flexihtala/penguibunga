using UnityEngine;

public class Killer : MonoBehaviour
{
    // review(26.06.2024): очень много похожего кода. На вашем месте я бы выделил базовый класс 
    // public abstract class PlayerTrigger : MonoBehaviour
    // {
    //     private void OnTriggerEnter2D(Collider2D other)
    //     {
    //         if (other.CompareTag("Player") && other.GetComponent<Player>() is {} player)
    //         {
    //             OnPlayerTriggerEnter2D(player);
    //         }
    //     }
    //
    //     public virtual void OnPlayerTriggerEnter2D(Player player)
    //     {
    //     }
    // }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var unit = other.GetComponent<Player>(); // review(26.06.2024): Хм, разве не нужно сначала проверить тег, а уже потом доставать компонент?
        if (unit && other.CompareTag("Player"))
        {
            unit.Die(unit);
        }
    }
}