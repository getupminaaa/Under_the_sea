using UnityEngine;

public class AnchorController : MonoBehaviour
{
    Rigidbody2D rigid;
    float speed;
    float maxHeight;
    bool bUp;

    // Start is called before the first frame update
    void Start()
    {
        maxHeight = gameObject.transform.position.y;
        rigid = gameObject.GetComponent<Rigidbody2D>();
        bUp = true;
        speed = 100;
    }

    // Update is called once per frame
    void Update()
    {
        rigid.velocity = Vector2.down * Time.deltaTime * (bUp ? -1 : 1) * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            bUp = true;
        }
        else
        {
            bUp = false;
        }
    }
}
