using UnityEngine;

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
        if (DistanceX > 1e-6)
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
                transform.position = position.ChangeByY(-Speed * Time.deltaTime);
            else
                movingUp = false;
        }
        else
        {
            if (position.y < downEdge)
                transform.position = position.ChangeByY(Speed * Time.deltaTime);
            else
                movingUp = true;
        }
    }


    private void MoveX()
    {
        var position = transform.position;
        if (movingLeft)
        {
            DeltaX = -Speed * Time.deltaTime;
            if (position.x > leftEdge)
                transform.position = position.ChangeByX(-Speed * Time.deltaTime);
            else
                movingLeft = false;
        }
        else
        {
            DeltaX = Speed * Time.deltaTime;
            if (position.x < rightEdge)
                transform.position = position.ChangeByX(Speed * Time.deltaTime);
            else
                movingLeft = true;
        }
    }
}