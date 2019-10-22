using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public Fcontroller character;
    GUIStyle guiStyle;
    const int maxRank = 21;

    private void Start()
    {
        guiStyle = new GUIStyle("Button");
        guiStyle.alignment = TextAnchor.MiddleCenter;
    }

    private void Update()
    {
       if (character.IsDead() && Input.GetKey(KeyCode.Space))
        {
            ReGame();
        }
    }

    private void OnGUI()
    {
        string text = "점수 : " + character.Score + "점";
        GUI.Label(new Rect(30, 10, text.Length * 10, 30), text, guiStyle);
        if (character.IsDead() && GUI.Button(new Rect(Screen.width / 2 - 75, Screen.height / 2 - 25, 150, 50), "다시 시작(Space)"))
        {
            ReGame();
        }

        if (GUI.Button(new Rect(Screen.width - 100 - 10, 10, 100, 35), "처음으로"))
        {
            GoMain();
        }
    }

    private void ReGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("게임플레이화면");
    }

    private void GoMain()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("게임플레이화면");
    }

    public void RecordRank(int score)
    {
        Debug.Log("점수는 " + score + "입니다.");
        for (int i = 1; i <= maxRank; i++)
        {
            int rankScore = PlayerPrefs.GetInt(i + "위", -1);
            if (score > rankScore)
            {
                Debug.Log(i + "위를 기록하였습니다.");
                for (int j = maxRank; j > i; j--)
                {
                    PlayerPrefs.SetInt(j + "위", PlayerPrefs.GetInt((j - 1) + "위", -1));
                }

                PlayerPrefs.SetInt(i + "위", score);
                break;
            }
        }

        score = 0;
    }

    public List<KeyValuePair<string, int>> GetRank()
    {
        List<KeyValuePair<string, int>> rank = new List<KeyValuePair<string, int>>();

        for (int i = 1; i <= maxRank; i++)
        {
            string name = PlayerPrefs.GetString(i + "위", null);
            int score = PlayerPrefs.GetInt(i + "위", -1);
            if (score != -1)
            {
                rank.Add(new KeyValuePair<string, int>(name, score));
            }
        }

        return rank;
    }
}