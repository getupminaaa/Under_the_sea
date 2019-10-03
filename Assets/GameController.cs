using UnityEngine;

public class GameController : MonoBehaviour
{
    private void Start()
    {

    }

    private void Update()
    {
        
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