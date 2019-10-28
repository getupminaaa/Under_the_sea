using System;
using System.Collections.Generic;
using UnityEngine;

public class Fcontroller : MonoBehaviour
{
    public GameController controller;

    public GameObject[] character;
    private int[] baseScore;

    private int index;
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
    }

    public float CalculateDistance(Vector2 beforePos, Vector2 afterPos)
    {
        float answer = 0;

        Vector2 distanceVec = afterPos - beforePos;
        answer = (float)Math.Sqrt(distanceVec.x * distanceVec.x + distanceVec.y * distanceVec.y);

        return answer;
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
            controller.retryBtn.SetActive(true);
            controller.RecordRank((int)score);
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
            controller.RecordRank((int)score);
            Time.timeScale = 0;
        }
    }

    public void SetSteerActive(bool active)
    {
        rb2d.isKinematic = !active;
    }

}
