using UnityEngine;

public class AnchorController : MonoBehaviour
{
    float speed;
    float maxHeight;

    // Start is called before the first frame update
    void Start()
    {
        maxHeight = gameObject.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Ground")
        {
            gameObject.transform.position = new Vector2(gameObject.transform.position.x, maxHeight);
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }
    }
}
