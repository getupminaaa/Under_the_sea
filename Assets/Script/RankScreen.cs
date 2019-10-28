using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RankScreen : MonoBehaviour
{

    private List<KeyValuePair<string, int>> ranks;
    private GUIStyle rightAlign;

    // Start is called before the first frame update
    void Start()
    {
        ranks = GetAllRank();
        rightAlign = new GUIStyle("Label");
        rightAlign.alignment = TextAnchor.MiddleRight;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnGUI()
    {
        if (GUI.Button(new Rect(10, 10, 100, 35), "뒤로 가기"))
        {
            SceneManager.LoadScene("대기화면");
        }

        float width = 400;
        int initY = 20, rankNum = ranks.Count;
        for (int i = 1; i <= rankNum; i++)
        {
            GUI.Label(new Rect((Screen.width - width) / 2, initY, 30, 20), i + "위", rightAlign);
            GUI.Label(new Rect((Screen.width - width) / 2 + 30, initY, 150, 20), ranks[i - 1].Key, rightAlign);
            GUI.Label(new Rect((Screen.width - width) / 2 + 100 + 100, initY, 130, 20), ranks[i - 1].Value.ToString(), rightAlign);

            initY += 25;
        }
    }

    public List<KeyValuePair<string, int>> GetAllRank()
    {
        List<KeyValuePair<string, int>> rank = new List<KeyValuePair<string, int>>();

        for (int i = 1; i <= GameController.maxRank; i++)
        {
            string name = PlayerPrefs.GetString(i + "위이름", "");
            int score = PlayerPrefs.GetInt(i + "위", -1);
            if (score != -1)
            {
                rank.Add(new KeyValuePair<string, int>(name, score));
            }
        }

        return rank;
    }
}
