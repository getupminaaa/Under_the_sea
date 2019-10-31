using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldenFeed : MonoBehaviour
{
    [HideInInspector]
    public float speed;
    [HideInInspector]
    public float startPosition;
    [HideInInspector]
    public float endPosition;


    public GameObject[] character;
    private void OnTriggerEnter2D(Collider2D colGF)
    {
        if (colGF.gameObject.tag == "Player")
        {
            Start();
            ScrollEnd();
            colGF.gameObject.transform.parent.GetComponent<Fcontroller>().gIgnore = true;
            colGF.gameObject.transform.parent.GetComponent<Fcontroller>().maxTime = 6.5f;

          
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
