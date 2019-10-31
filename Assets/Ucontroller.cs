using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class uController : MonoBehaviour
{
    public float validatedTime;
    public float maxTime;
    public float uScale;
    public bool uChSize;
    // Start is called before the first frame update
    void Start()
    {
        uChSize = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (uChSize)
        {
            validatedTime += Time.deltaTime;
            gameObject.transform.localScale = new Vector2(0.5f, 0.5f) * uScale;
        }
        if (maxTime <= validatedTime)
        {
            uChSize = false;
            validatedTime = 0;
            gameObject.transform.localScale = new Vector2(0.5f,0.5f);
        }
    }
}
