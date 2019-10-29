using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadMainScene : MonoBehaviour
{
    public void GoToMainScene()
    {
        SceneManager.LoadScene("대기화면");
    }
}
