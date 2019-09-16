using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fcontroller : MonoBehaviour
{

    Rigidbody2D rb2d;
    bool isDead;

    public float maxHeight;
    public float thrust;

    public bool IsDead()
    {
        return isDead;
    }

    // Start is called before the first frame update
    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead) return;
        if (Input.GetKey(KeyCode.UpArrow) == true) {
            rb2d.AddForce(transform.up * thrust * Time.deltaTime);
            Debug.Log("UpArrow");
        } else if (Input.GetKey(KeyCode.DownArrow) == true)
        {
            rb2d.AddForce(transform.up* -1 * thrust * Time.deltaTime);
            Debug.Log("DownArrow");
        } else if (Input.GetKey(KeyCode.RightArrow) == true)
        {
            Debug.Log("RightArrow");
            rb2d.AddForce(transform.right * thrust * Time.deltaTime);
        } else if(Input.GetKey(KeyCode.LeftArrow) == true)
        {
            rb2d.AddForce(transform.right* -1 * thrust * Time.deltaTime);
            Debug.Log("LeftArrow");
        }


    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (isDead) return;
        //Camera.main.SendMessage("Clash");
        isDead = true;
    }
    public void SetSteerActive(bool active)
    {
        rb2d.isKinematic = !active;
    }

}
