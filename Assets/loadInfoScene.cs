using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadInfoScene : MonoBehaviour
{
 public void GoToInfoScene()
    {
        SceneManager.LoadScene("게임설명화면"); 
    }
}
