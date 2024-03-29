﻿using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Fcontroller character;
    GUIStyle guiStyle;
    public GameObject retryBtn;
    public Text scoreTxt;
    public const int maxRank = 21;

    private void Start()
    {
        guiStyle = new GUIStyle("Button");
        guiStyle.alignment = TextAnchor.MiddleCenter;
        retryBtn.SetActive(false);

        Time.timeScale = 1;
    }

    private void Update()
    {
        scoreTxt.text = "점수 : " + character.Score.ToString("0.00") + "점";
        if (character.IsDead() && Input.GetKey(KeyCode.Space))
        {
            ReGame();
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

    public void GoMain()
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