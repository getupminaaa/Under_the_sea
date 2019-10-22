using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadRankScene : MonoBehaviour
{
    public void GoToRankScene()
    {
        SceneManager.LoadScene("랭킹화면");
    }
}
