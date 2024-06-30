using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class MovingObject : MonoBehaviour
{
    public float DistanceX;
    public float DistanceY;
    public float Speed;
    public bool LeftToRight;
    public bool DownToUp;
    public float DeltaX;

    private float downEdge;
    private float leftEdge;
    private bool movingLeft;
    private bool movingUp;
    private float rightEdge;
    private float upEdge;


    public void Awake()
    {
        var position = transform.position;
        rightEdge = position.x;
        leftEdge = position.x;
        upEdge = position.y;
        downEdge = position.y;
        if (LeftToRight)
            rightEdge += DistanceX;
        else
            leftEdge -= DistanceX;

        if (DownToUp)
            downEdge += DistanceY;
        else
            upEdge -= DistanceY;
    }

    private void Update()
    {
        // review(26.06.2024): Я убежден, что DistanceX, DistanceY вполне можно заменить на 2d вектор
        if (DistanceX > 1e-6) // review(26.06.2024): Стоило вынести константу либо метод добавить на корректную проверку == 0
            MoveX();
        if (DistanceY > 1e-6)
            MoveY();
    }


    private void MoveY()
    {
        var position = transform.position;
        if (movingUp)
        {
            if (position.y > upEdge)
            {
                float y = -Speed * Time.deltaTime;
                transform.position = position + new Vector3(0, y, 0);
            }
            else
                movingUp = false;
        }
        else
        {
            if (position.y < downEdge)
            {
                float y = Speed * Time.deltaTime;
                transform.position = position + new Vector3(0, y, 0);
            }
            else
                movingUp = true;
        }
    }

    // review(26.06.2024): Не поленился и сократил код до нескольких строчек. Вангую, можно пойти еще дальше и не потерять в понятности
    private void MoveX2()
    {
        var position = transform.position;
        DeltaX = (movingLeft ? -Speed : Speed) * Time.deltaTime;

        if (position.x > leftEdge && position.x < rightEdge)
            transform.position = position + new Vector3(DeltaX, 0, 0);
        else
            movingLeft = !movingLeft;
    }

    private void MoveX()
    {
        var position = transform.position;
        if (movingLeft)
        {
            DeltaX = -Speed * Time.deltaTime;
            if (position.x > leftEdge)
            {
                float x = -Speed * Time.deltaTime;
                transform.position = position + new Vector3(x, 0, 0);
            }
            else
                movingLeft = false;
        }
        else
        {
            DeltaX = Speed * Time.deltaTime;
            if (position.x < rightEdge)
            {
                float x = Speed * Time.deltaTime;
                transform.position = position + new Vector3(x, 0, 0);
            }
            else
                movingLeft = true;
        }
    }
}