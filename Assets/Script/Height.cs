using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Height : MonoBehaviour
{
    public float minHeight;
    public float maxHeight;
    public GameObject thing;
    // Start is called before the first frame update
    void Start()
    {
        ChangeHeight();
    }

    // Update is called once per frame
    void ChangeHeight()
    {
        float height = Random.Range(minHeight, maxHeight);
        thing.transform.localPosition = new Vector3(thing.transform.localPosition.x, height, 0.0f);
    }
    void OnScrollEnd()
    {
        ChangeHeight();
   
    }
}

