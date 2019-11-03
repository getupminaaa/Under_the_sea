using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UController : MonoBehaviour
{
    public float uvalidatedTime;
    public float umaxTime;
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
            uvalidatedTime += Time.deltaTime;
            gameObject.transform.localScale = new Vector2(0.5f, 0.5f) * uScale;
        }
        if (umaxTime <= uvalidatedTime)
        {
            uChSize = false;
            uvalidatedTime = 0;
            gameObject.transform.localScale = new Vector2(0.5f, 0.5f);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // if (collision.gameObject.tag == "Obstacle") Physics2D.IgnoreCollision(collision.collider, this.GetComponent<Collider2D>());
    }
}
