﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadPlayScene : MonoBehaviour
{
    public void GoToPlayScene()
    {
        SceneManager.LoadScene("게임플레이화면"); 
    }
}
