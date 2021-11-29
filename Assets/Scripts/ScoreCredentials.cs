using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCredentials : MonoBehaviour
{
  
    [SerializeField]
    private Player _playerScript;
    [SerializeField]
    private SubMenu _subMenuScript;
    [SerializeField]
    private HighScoreList _highScoreListScript;
    [SerializeField]
    public GameObject ScoreCreditObj;
    [SerializeField]
    private Text score;
    [SerializeField]
    private Text Playername;
    
    
    
    private int letterIndex=0;
    int selectedLettersIndex=0;
    private string Strname;
    public bool ScoreCred=false;
    
    
    private char[] SelectedLetters= new char[]
    {
        
        ' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' '
    };
    
    
    
    char[] letters = 
    {
        'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w',
        'x', 'y', 'z', 'å', 'ä', 'ö'
    };

    
    
    
    

 
    void Start()
    {
        
        _highScoreListScript = GameObject.Find("Canvas").GetComponent<HighScoreList>();
        _subMenuScript =GameObject.Find("Canvas").GetComponent<SubMenu>();
        _playerScript =GameObject.Find("Player").GetComponent<Player>();
       
    }

   
    void Update()
    {
         if (ScoreCred == true)
         {
                    
               
                
                if (Input.GetKeyDown(KeyCode.A))
                {
                    selectedLettersIndex--;
                    if (selectedLettersIndex < 0)
                    {
                        selectedLettersIndex = selectedLettersIndex-1;
                    }
                  
                }
        
                if (Input.GetKeyDown(KeyCode.D))
                {
                    selectedLettersIndex++;
                    if (selectedLettersIndex > SelectedLetters.Length-1)
                    {
                        selectedLettersIndex = 0;
                    }
                }
                if (Input.GetKeyDown(KeyCode.W))
                {
                    letterIndex--;
                    if (letterIndex < 0)
                    {
                        letterIndex = 27;
                    }
                    SelectedLetters[selectedLettersIndex] = letters[letterIndex];
                }
        
                if (Input.GetKeyDown(KeyCode.S))
                {
                    letterIndex++;
                    if (letterIndex > 27)
                    {
                        letterIndex = 0;
                    }
        
                    SelectedLetters[selectedLettersIndex] = letters[letterIndex];
                }
        
                if (Input.GetKeyDown(KeyCode.Return))
                {
                     
                  
                    ScoreCreditObj.SetActive(false);
                    ScoreCred = false;
                    _subMenuScript.menu.SetActive(true);
                    _highScoreListScript.addScore(_playerScript.score,Strname);
                  
                }

                Strname=new string(SelectedLetters);


                score.text = _playerScript.score.ToString();

                Playername.text = Strname;

                




         }
    }
}
