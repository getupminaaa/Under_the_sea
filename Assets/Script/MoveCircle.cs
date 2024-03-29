﻿using UnityEngine;

public class MoveCircle : MonoBehaviour
{
    public float speed = 2f;
    public float radius = 0.07f;

    private Vector2 center;
    private float angle;

    private void Start()
    {
        center = transform.position;
    }

    private void Update()
    {
        if (Time.deltaTime != 0)
        {
            angle += speed * Time.deltaTime;

            transform.Translate(new Vector2(Mathf.Sin(angle), Mathf.Cos(angle)) * radius);
        }
    }
}
