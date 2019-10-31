using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Feed : MonoBehaviour
{
    [HideInInspector]
    public float speed;
    [HideInInspector]
    public float startPosition;
    [HideInInspector]
    public float endPosition;
    public Fcontroller fcon;

    public GameObject[] character;
    private void OnTriggerEnter2D(Collider2D colFe)
    {
        if (colFe.gameObject.tag == "Player")
        {
            Start();
            ScrollEnd();
            fcon.keyDirec = -1;
            fcon.nmaxTime = 6.5f;
            fcon.fChaKey = true;
            fcon.Score += 15;
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
