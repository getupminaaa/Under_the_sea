using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadHideScene : MonoBehaviour
{
    public void GoToHideScene()
    {
        SceneManager.LoadScene("숨겨진타이틀씬");
    }
}
