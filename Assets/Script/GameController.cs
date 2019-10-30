using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public Fcontroller character;
    GUIStyle guiStyle;
    public GameObject retryBtn;
    public const int maxRank = 21;

    private void Start()
    {
        guiStyle = new GUIStyle("Button");
        guiStyle.alignment = TextAnchor.MiddleCenter;
        retryBtn.SetActive(false);
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
        string text = "점수 : " + character.Score.ToString("0.00") + "점";
        if (GUI.Button(new Rect(Screen.width - 100 - 10, 10, 100, 35), "처음으로"))
        {
            GoMain();
        }
    }

    public void ReGame()
    {
        Time.timeScale = 1;
        if (character.IsDead())
        {
            RecordRank(character.Name, (int)character.Score);
        }

        SceneManager.LoadScene("게임플레이화면");
    }

    private void GoMain()
    {
        Time.timeScale = 1;
        if (character.IsDead())
        {
            RecordRank(character.Name, (int)character.Score);
        }
        SceneManager.LoadScene("대기화면");
    }

    public void RecordRank(string name, int score)
    {
        int rank = 0;
        for (int i = 1; i <= maxRank; i++)
        {
            int rankScore = PlayerPrefs.GetInt(i + "위", -1);
            if (score > rankScore)
            {
                Debug.Log(i + "위를 기록하였습니다.");
                for (int j = maxRank; j > i; j--)
                {
                    PlayerPrefs.SetString(j + "위이름", PlayerPrefs.GetString((j - 1) + "위이름", null));
                    PlayerPrefs.SetInt(j + "위", PlayerPrefs.GetInt((j - 1) + "위", -1));
                }

                rank = i;
                break;
            }
        }

        if (rank != 0)
        {
            PlayerPrefs.SetString(rank + "위이름", name);
            PlayerPrefs.SetInt(rank + "위", score);

            Debug.Log("Second");
            Debug.Log("이름은 " + PlayerPrefs.GetString(rank + "위이름", "") + "입니다.");
            Debug.Log("점수는 " + PlayerPrefs.GetInt(rank + "위", -1) + "입니다.");
        }
    }
}