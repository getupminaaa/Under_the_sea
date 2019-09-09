using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fcontroller : MonoBehaviour
{

    Rigidbody2D rb2d;
    bool isDead;

    public float maxHeight;
    public float flapVelocity;

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
        if (Input.GetButtonDown("Fire1") && transform.position.y < maxHeight) { Flap(); }

    }
    public void Flap()
    {
        if (isDead) return;
        if (rb2d.isKinematic) return;
        rb2d.velocity = new Vector2(0.0f, flapVelocity);
    }
  
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (isDead) return;
        Camera.main.SendMessage("Clash");
        isDead = true;
    }
    public void SetSteerActive(bool active)
    {
        rb2d.isKinematic = !active;
    }
}
