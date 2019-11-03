using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RankScreen : MonoBehaviour
{

    private List<KeyValuePair<string, int>> ranks;
    private GUIStyle textAlign;
    private int page;
    public int Page
    {
        get
        {
            return page;
        }

        set
        {
            if (value < 0)
            {
                page = 0;
            }
            else if (value > 2)
            {
                page = 2;
            }
            else
            {
                page = value;
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        page = 0;
        ranks = GetAllRank();
        textAlign = new GUIStyle("Label");
        textAlign.fontSize = 25;
        textAlign.normal.textColor = Color.black;
        textAlign.alignment = TextAnchor.MiddleRight;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnGUI()
    {
        int y = 170, height = 30, rankNum = ranks.Count;
        for (int i = page * 7 + 1; i <= (page + 1) * 7; i++)
        {
            if (ranks[i - 1].Value == -1) break;
            // 1280 * 720

            GUI.Label(new Rect(170, y, 60, height), i + "위", textAlign);
            GUI.Label(new Rect(260, y, 370, height), ranks[i - 1].Key, textAlign);
            GUI.Label(new Rect(660, y, 450, height), ranks[i - 1].Value.ToString(), textAlign);

            y += 62;
        }

        y = 620;
        if (GUI.Button(new Rect((Screen.width - 50) / 2, y, height, height), "<"))
        {
            Page--;
        }

        if (GUI.Button(new Rect((Screen.width + 50) / 2, y, height, height), ">"))
        {
            Page++;
        }
    }

    public List<KeyValuePair<string, int>> GetAllRank()
    {
        List<KeyValuePair<string, int>> rank = new List<KeyValuePair<string, int>>();

        for (int i = 1; i <= GameController.maxRank; i++)
        {
            string name = PlayerPrefs.GetString(i + "위이름", "");
            int score = PlayerPrefs.GetInt(i + "위", -1);

            rank.Add(new KeyValuePair<string, int>(name, score));
        }

        return rank;
    }
}
