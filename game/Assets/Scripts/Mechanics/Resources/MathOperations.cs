using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MathOperations
{
    public static float getEuclideanDistance(Vector2 vector1, Vector2 vector2)
    {
        return Mathf.Sqrt(Mathf.Pow((vector2.x - vector1.x), 2) + Mathf.Pow((vector2.y - vector1.y), 2));
    }
}
