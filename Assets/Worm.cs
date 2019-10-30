using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Worm : MonoBehaviour
{
    [HideInInspector]
    public float speed;
    [HideInInspector]
    public float startPosition;
    [HideInInspector]
    public float endPosition;
    int kTime = 4;
    public GameObject[] character;
    private void OnTriggerEnter2D(Collider2D colWo)
    {
        if (colWo.gameObject.tag == "Player")
        {
            Start();
            ScrollEnd();
            gameObject.GetComponent<Fcontroller>().bScale = true;
            gameObject.GetComponent<Fcontroller>().maxTime = 3.8f;
        }
    }
    //if (붙이힌 객체가 물고기인지 확인){
    //물고기니까
 
    //}
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
