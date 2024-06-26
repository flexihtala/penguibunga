using System.Collections;
using UnityEngine;

public class PressController : Killer
{
    public float moveSpeed = 2.0f;
    public Transform lowerPoint;
    public Transform upperPoint;

    private bool movingDown = true;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(MovePress());
    }

    private IEnumerator MovePress()
    {
        // review(26.06.2024): Стоило хотя бы какой-нибудь флаг добавить в качестве условия, а то этот цикл ведь реально никогда не прекратится, а такая потребность обязательно возникнет
        while (true) // review(26.06.2024): Зажали скобки, ясно
            if (movingDown)
            {
                // review(26.06.2024): Стоило выделить transform.position в переменную
                while (transform.position.y > lowerPoint.position.y)
                {
                    transform.position = Vector2.MoveTowards(transform.position,
                        new Vector2(transform.position.x, lowerPoint.position.y), moveSpeed * Time.deltaTime * 20); // review(26.06.2024): магическая константа. Стоило выделить moveDownSpeed/moveUpSpeed
                    yield return null;
                }
                yield return new WaitForSeconds(0.2f); // review(26.06.2024): WaitForSeconds - это класс. Соответственно, вы часто создаете один и тот же объект. Можно выделить в статическое поле 
                movingDown = false;
                
            }
            else
            {
                while (transform.position.y < upperPoint.position.y)
                {
                    transform.position = Vector2.MoveTowards(transform.position,
                        new Vector2(transform.position.x, upperPoint.position.y), moveSpeed * Time.deltaTime);
                    yield return null;
                }

                yield return new WaitForSeconds(1.0f); // review(26.06.2024): аналогично
                movingDown = true;
                audioSource.PlayOneShot(audioSource.clip);
            }
    }
}