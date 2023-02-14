using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizeLightStreak : MonoBehaviour
{
    public Vector2 streakWidthRange = new(2, 2);

    private void Awake()
    {
        var lr = GetComponent<LineRenderer>();
        var l = GetComponent<Light>();
        var r = Random.Range(streakWidthRange.x, streakWidthRange.y);

        if (lr != null)
        {
            lr.startWidth = r;
            lr.endWidth = r;
        }

        if (l != null && l.type == LightType.Spot) l.spotAngle = r * 3;
    }
}