using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public Fcontroller character;
    GUIStyle guiStyle;

    private void Start()
    {
        guiStyle = new GUIStyle("Button");
        guiStyle.alignment = TextAnchor.MiddleCenter;
    }

    private void Update()
    {
       if (character.IsDead() && Input.GetKey(KeyCode.Space))
        {
            Time.timeScale = 1;
            SceneManager.LoadScene("SampleScene");
        }
    }

    private void OnGUI()
    {
        string text = "점수 : " + character.Score + "점";
        GUI.Label(new Rect(30, 10, text.Length * 10, 30), text, guiStyle);
        if (character.IsDead() && GUI.Button(new Rect(Screen.width / 2 - 75, Screen.height / 2 - 25, 150, 50), "다시 시작(Space)"))
        {
            Time.timeScale = 1;
            SceneManager.LoadScene("SampleScene");
        }
    }

    public void RecordRank(int score)
    {
        Debug.Log("점수는 " + score + "입니다.");
        for (int i = 1; i <= 10; i++)
        {
            int rankScore = PlayerPrefs.GetInt(i + "위", -1);
            if (score > rankScore)
            {
                Debug.Log(i + "위를 기록하였습니다.");
                for (int j = 10; j > i; j--)
                {
                    PlayerPrefs.SetInt(j + "위", PlayerPrefs.GetInt((j - 1) + "위", -1));
                }

                PlayerPrefs.SetInt(i + "위", score);
                break;
            }
        }

        score = 0;
    }
}