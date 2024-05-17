using System.Collections;
using UnityEngine;

public class PressController : Killer
{
    public float moveSpeed = 2.0f; // Скорость движения пресса
    public Transform lowerPoint; // Нижняя точка движения
    public Transform upperPoint; // Верхняя точка движения

    private bool movingDown = true; // Флаг для направления движения

    private void Start()
    {
        StartCoroutine(MovePress());
    }

    private IEnumerator MovePress()
    {
        while (true)
            if (movingDown)
            {
                while (transform.position.y > lowerPoint.position.y)
                {
                    transform.position = Vector2.MoveTowards(transform.position,
                        new Vector2(transform.position.x, lowerPoint.position.y), moveSpeed * Time.deltaTime * 20);
                    yield return null;
                }
                yield return new WaitForSeconds(0.2f);
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

                yield return new WaitForSeconds(1.0f);
                movingDown = true;
            }
    }
}