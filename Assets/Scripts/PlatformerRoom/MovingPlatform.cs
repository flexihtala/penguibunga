using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float DistanceX;
    public float DistanceY;
    public float speed;
    public float deltaX;
    private float downEdge;
    private float leftEdge;
    private bool movingLeft;
    private bool movingUp;
    private float rightEdge;
    private float upEdge;

    public bool LeftToRight;
    public bool DownToUp;


    public void Awake()
    {
        if (LeftToRight)
        {
            leftEdge = transform.position.x;
            rightEdge = transform.position.x + DistanceX;
        }
        else
        {
            leftEdge = transform.position.x - DistanceX;
            rightEdge = transform.position.x;
        }
        if (DownToUp)
        {
            upEdge = transform.position.y;
            downEdge = transform.position.y + DistanceY;
        }
        else
        {
            upEdge = transform.position.y - DistanceY;
            downEdge = transform.position.y;
        }
    }


    // Update is called once per frame
    private void Update()
    {
        if (DistanceX > 1e-6)
            MoveX();
        if (DistanceY > 1e-6)
            MoveY();
    }

    private void MoveY()
    {
        if (movingUp)
        {
            if (transform.position.y > upEdge)
                transform.position = new Vector3(transform.position.x, transform.position.y - speed * Time.deltaTime,
                    transform.position.z);
            else
                movingUp = false;
        }
        else
        {
            if (transform.position.y < downEdge)
                transform.position = new Vector3(transform.position.x, transform.position.y + speed * Time.deltaTime,
                    transform.position.z);
            else
                movingUp = true;
        }
    }

    private void MoveX()
    {
        if (movingLeft)
        {
            if (transform.position.x > leftEdge)
            {
                deltaX = -speed * Time.deltaTime;
                transform.position = new Vector3(transform.position.x + deltaX, transform.position.y,
                    transform.position.z);
            }
            else
                movingLeft = false;
        }
        else
        {
            if (transform.position.x < rightEdge)
            {
                deltaX = speed * Time.deltaTime;
                transform.position = new Vector3(transform.position.x + deltaX, transform.position.y,
                    transform.position.z);
            }
            else
                movingLeft = true;
        }
    }
}