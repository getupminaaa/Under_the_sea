using UnityEngine;

public class Fcontroller : MonoBehaviour
{
    public GameController controller;

    [HideInInspector]
    public int score;

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
        Initalize();
    }

    public void Initalize()
    {
        score = 0;
        isDead = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow) == true)
        {
            rb2d.AddForce(transform.up * thrust * Time.deltaTime);
            Debug.Log("UpArrow");
        }
        else if (Input.GetKey(KeyCode.DownArrow) == true)
        {
            rb2d.AddForce(transform.up * -1 * thrust * Time.deltaTime);
            Debug.Log("DownArrow");
        }
        else if (Input.GetKey(KeyCode.RightArrow) == true)
        {
            Debug.Log("RightArrow");
            rb2d.AddForce(transform.right * thrust * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.LeftArrow) == true)
        {
            rb2d.AddForce(transform.right * -1 * thrust * Time.deltaTime);
            Debug.Log("LeftArrow");
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (isDead) return;
        if (collision.collider.tag == "Item")
        {
            score++;
        }
        else
        {
            isDead = true;
            controller.RecordRank(score);
            Time.timeScale = 0;
        }
        
        //Camera.main.SendMessage("Clash");
    }

    public void SetSteerActive(bool active)
    {
        rb2d.isKinematic = !active;
    }

}
