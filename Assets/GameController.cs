using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class GameController : MonoBehaviour
{
    enum State
    {
        Ready,
        Play,
        GameOver
    }
    State state;
    int score;

    public Fcontroller fish;
    public GameObject Blocks;
    public GameObject Feeds;
    public GameObject Rocks;
    public Text ScoreLabel;
    public Text StateLabel;

    void Start()
    {
        Ready();
    }

    void LateUpdate()
    {
        switch (state)
        {
            case State.Ready:
                if (Input.GetButtonDown("Fire1")) GameStart();
                break;
            case State.Play:
                if (fish.IsDead()) GameOver();
                break;
            case State.GameOver:
                if (Input.GetButtonDown("Fire1")) Reload();
                break;
        }
    }
    void Ready()
    {
        state = State.Ready;
        fish.SetSteerActive(false);
        Blocks.SetActive(false);
        Feeds.SetActive(false);
        Rocks.SetActive(false);

        ScoreLabel.text = "Score:" + 0;

        StateLabel.gameObject.SetActive(true);
        StateLabel.text = "Ready";
    }
    void GameStart()
    {
        state = State.Play;
        fish.SetSteerActive(true);
        Blocks.SetActive(true);
        Feeds.SetActive(true);
        Rocks.SetActive(true);

        fish.Flap();

        StateLabel.gameObject.SetActive(false);
        StateLabel.text = "";
    }
    void GameOver()
    {
        state = State.GameOver;
        ScrollObject[] scrollObjects = GameObject.FindObjectsOfType<ScrollObject>();
        foreach (ScrollObject so in scrollObjects) so.enabled = false;


        StateLabel.gameObject.SetActive(true);
        StateLabel.text = "GameOver";
    }
    void Reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void IncreaseScore()
    {
        score++;
        ScoreLabel.text = "Score:" + score;
    }
}
