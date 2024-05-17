using UnityEngine;

public class MovingSaw : Killer
{
    public float DistanceX;
    public float DistanceY;
    public float speed;
    private float downEdge;
    private float leftEdge;
    private bool movingLeft;
    private bool movingUp;
    private float rightEdge;
    private float upEdge;


    public void Awake()
    {
        leftEdge = transform.position.x - DistanceX;
        rightEdge = transform.position.x + DistanceX;

        upEdge = transform.position.y - DistanceY;
        downEdge = transform.position.y + DistanceY;
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
                transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y,
                    transform.position.z);
            else
                movingLeft = false;
        }
        else
        {
            if (transform.position.x < rightEdge)
                transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y,
                    transform.position.z);
            else
                movingLeft = true;
        }
    }
}