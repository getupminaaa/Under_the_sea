using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeController : MonoBehaviour
{
    int time = 3;
    SpriteRenderer sr;
    private bool fade;

    private void Start()
    {
        sr = this.gameObject.GetComponent<SpriteRenderer>();
        fade = true;
    }

    private void Update()
    {
        Color tempColor = sr.color;
        if (!fade)
        {
            tempColor.a -= Time.deltaTime / time;
            sr.color = tempColor;

            if (tempColor.a <= 0f)
            {
                tempColor.a = 0f;
                fade = true;
            }
        }
        else
        {
            tempColor.a += Time.deltaTime / time;
            sr.color = tempColor;

            if (tempColor.a >= 1f)
            {
                tempColor.a = 1f;
                fade = false;
            }
        }

        sr.color = tempColor;
    }
}


