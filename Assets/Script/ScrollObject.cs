using System.Collections;
using UnityEngine;

public class ScrollObject : MonoBehaviour
{
    [HideInInspector]
    public float speed;
    [HideInInspector]
    public float startPosition;
    [HideInInspector]
    public float endPosition;

    private void Start()
    {
        speed = 4;
        startPosition = 35;
        endPosition = -startPosition;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-1 * speed * Time.deltaTime, 0, 0);
        if (transform.position.x <= endPosition) ScrollEnd();
    }
    void ScrollEnd()
    {
        transform.Translate(-1 * (endPosition - startPosition), 0, 0);
        SendMessage("OnScrollEnd", SendMessageOptions.DontRequireReceiver);
    }
}