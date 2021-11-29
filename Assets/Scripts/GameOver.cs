using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameOver : MonoBehaviour
{
    [SerializeField]
    private ScoreCredentials _scoreCredentialsScript;

    private movement _movementScript;
   
    void Start()
    {
        _movementScript = GameObject.Find("Player").GetComponent<movement>();
        _scoreCredentialsScript = GameObject.Find("Canvas").GetComponent<ScoreCredentials>();

    }
    public void gameover()
   {
       _movementScript.gameOver = true;
       _scoreCredentialsScript.ScoreCred = true;
       _scoreCredentialsScript.ScoreCreditObj.SetActive(true);
            
            
   }

}
