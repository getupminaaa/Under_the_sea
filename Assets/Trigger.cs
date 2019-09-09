using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    GameObject gameConroller;
    void Start()
    {
        gameConroller = GameObject.FindWithTag("GameController");
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        gameConroller.SendMessage("IncreaseScore");
    }
}
