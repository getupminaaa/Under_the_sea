using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shrimp : MonoBehaviour
{
    [HideInInspector]
    public float speed;
    [HideInInspector]
    public float startPosition;
    [HideInInspector]
    public float endPosition;

    
    public GameObject[] character;
    private void OnTriggerEnter2D(Collider2D colSh)
    {
        if (colSh.gameObject.tag == "Player")
        {
            Start();
            ScrollEnd();
        }
    }
    // Start is called before the first frame update
    private void Start()
    {
        speed = 4;
        startPosition = 35;
        endPosition = -startPosition;
    }
    void ScrollEnd()
    {
        transform.Translate(-1 * (endPosition - startPosition), 0, 0);
        SendMessage("OnScrollEnd", SendMessageOptions.DontRequireReceiver);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
