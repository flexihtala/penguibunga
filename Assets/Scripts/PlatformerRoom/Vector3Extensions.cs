using UnityEngine;

public static class Vector3Extensions
{
    public static Vector3 ChangeByX(this Vector3 vector, float x)
    {
        return new Vector3(vector.x + x, vector.y, vector.z);
    }

    public static Vector3 ChangeByY(this Vector3 vector, float y)
    {
        return new Vector3(vector.x, vector.y + y, vector.z);
    }
}