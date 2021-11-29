using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using UnityEngine;
using UnityEngine.UI;

public class SubMenu : MonoBehaviour
{
   
    public GameObject menu;
    private movement _movementScript;

    void Start() { _movementScript = GameObject.Find("Player").GetComponent<movement>(); }
    public void playAgain()
    {
       
       
       
        SceneManager.LoadScene("MainScene", LoadSceneMode.Single);
       
       _movementScript.gameOver = false;

    }
}
