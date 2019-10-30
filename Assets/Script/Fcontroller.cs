using System;
using System.Collections.Generic;
using UnityEngine;

public class Fcontroller : MonoBehaviour
{
    public GameController controller;

    public GameObject[] character;
    private int[] baseScore;
    public float validatedTime;
    public float maxTime;
    public bool bScale;
    private int index;
    public string Name { get; private set; }
    private float score;
    public float Score
    {
        get { return score; }

        set
        {
            if (index < baseScore.Length && value >= baseScore[index])
            {
                character[index + 1].SetActive(true);
                character[index].SetActive(false);
                index++;
            }

            score = value;
        }
    }

    Rigidbody2D rb2d;
    bool isDead;

    public float maxHeight;

    Vector2 presentPos;
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

        index = 0;
        baseScore = new int[character.Length - 1];
        baseScore[0] = 12;
        baseScore[1] = 30;
        // baseScore[2] = 50;

        for (int i = 1; i < character.Length; i++)
        {
            character[i].SetActive(false);
        }
    }

    public void Initalize()
    {
        score = 0;
        Name = "";
        isDead = false;

        presentPos = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow) == true)
        {
            rb2d.AddForce(transform.up * thrust * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.DownArrow) == true)
        {
            rb2d.AddForce(transform.up * -1 * thrust * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.RightArrow) == true)
        {
            rb2d.AddForce(transform.right * thrust * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.LeftArrow) == true)
        {
            rb2d.AddForce(transform.right * -1 * thrust * Time.deltaTime);
        }

        float add = CalculateDistance(presentPos, gameObject.transform.position);
        Score += add;
        presentPos = gameObject.transform.position;

        if (bScale)
        { 
            validatedTime += Time.deltaTime;
            gameObject.transform.localScale = new Vector2(1.8f,1.8f);
        }
        if (maxTime <= validatedTime)
        {
            bScale = false;
            validatedTime = 0;
            gameObject.transform.localScale = new Vector2(1, 1);
        }
    }

    public float CalculateDistance(Vector2 beforePos, Vector2 afterPos)
    {
        float answer = 0;

        Vector2 distanceVec = afterPos - beforePos;
        answer = (float)Math.Sqrt(distanceVec.x * distanceVec.x + distanceVec.y * distanceVec.y);

        return answer;
    }

    private void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 100, 30), Score.ToString("0.00"), new GUIStyle("Button"));
        if (!isDead)
        {
            return;
        }
        else
        {
            controller.retryBtn.SetActive(true);
        }

        Name = GUI.TextField(new Rect((Screen.width - 300) / 2, 120, 300, 30), Name);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (isDead) return;
        if (collision.collider.tag == "Item")
        {
            Score++;
        }
        else
        {
            isDead = true;
            controller.retryBtn.SetActive(true);
            Time.timeScale = 0;
        }
        
        //Camera.main.SendMessage("Clash");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isDead) return;
        if (collision.tag == "Background")
        {
            isDead = true;
            Time.timeScale = 0;
        }
    }

    public void SetSteerActive(bool active)
    {
        rb2d.isKinematic = !active;
    }
}
