using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class movement : MonoBehaviour
{
    
    
   
    private int _gridCoordinateX=5;
    private int _gridCoordinateY=5;
    private int[] directions= new []{ 1, -1, -1, 1 };
    private int directionIndex=0;
    private int _moveDirectionX=1;
    private int _moveDirectionY=0;
    private int oldDirX;
    private int oldDirY;
    
    private Vector3 oldPos;
    
    public  bool GameActive = false;
    public bool gameOver = false;
    private bool buttonPushed;
    
    
    public GameObject player;
    
    
    private Player _player;
    private GameOver _gameOverScript;
    private SpriteRenderer sr;
    
    [SerializeField]
    private Sprite monkeyup;
    [SerializeField]
    private Sprite monkeyright;
    [SerializeField]
    private Sprite monkeydown;
    [SerializeField]
    private Sprite monkeyleft;
    [SerializeField]
    private Sprite monkeytaily;
    [SerializeField]
    private Sprite monkeytailx;

    

    

    

    void Start()
    {
        // making interaction between scripts available
        _player = GetComponent<Player>();
        sr = player.GetComponent<SpriteRenderer>();
        _gameOverScript = GameObject.Find("Canvas").GetComponent<GameOver>();
        
        
        
        StartCoroutine(Move());
     
        player.transform.position = Grid.tiles[_gridCoordinateX, _gridCoordinateY];
       
       


       

    }

   // Listening for inputs that change the player direction and select sprites with regard to direction
    void Update()
    {

        if (Input.anyKey&&gameOver==false)
        {
            GameActive = true;

        }
        
        if (GameActive==true)
        {

            if (directionIndex == 0)
            {

                sr.sprite = monkeyright;

            }
            else if (directionIndex == 1)
            {
                sr.sprite = monkeyup;
                
            }
            else if (directionIndex == 2)
            {
                sr.sprite = monkeyleft;
            }
            if (directionIndex == 3)
            {
                sr.sprite = monkeydown;
            }

            if (buttonPushed == false&&gameOver==false)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    

                }
                if (Input.GetKeyDown(KeyCode.D))
                {
                    buttonPushed = true;
                    directionIndex--;
                }

                if (Input.GetKeyDown(KeyCode.A))
                {
                    buttonPushed = true;
                    directionIndex++;
                }

                if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    buttonPushed = true;
                    directionIndex++;
                }

                if (Input.GetKeyDown(KeyCode.RightArrow))
                { 
                    buttonPushed = true;
                    
                    directionIndex--;
                }
                
                if (directionIndex > 3) {directionIndex = 0;}
               
                    else if (directionIndex < 0){directionIndex = 3;}
                            
                 
            }
        }
    }
//Moves the player according to direction and stores the direction and position to be used in the linked list
    IEnumerator Move()
    {
        

        while (true)
        {
            if (GameActive == true&& gameOver==false)
            {
                if (directionIndex == 0)
                {
                    oldDirX = _moveDirectionX;
                    oldDirY = _moveDirectionY;
                    _gridCoordinateX++;
                    _moveDirectionX = directions[directionIndex];
                    _moveDirectionY = 0;

                }

                if (directionIndex == 1)
                {  
                    oldDirX = _moveDirectionX;
                    oldDirY = _moveDirectionY;
                    _gridCoordinateY++;
                    _moveDirectionY = directions[directionIndex];
                    _moveDirectionX = 0;

                }

                if (directionIndex == 2)
                {
                    oldDirX = _moveDirectionX;
                    oldDirY = _moveDirectionY;
                    _gridCoordinateX--;
                    _moveDirectionX = directions[directionIndex];
                    _moveDirectionY = 0;


                }

                if (directionIndex == 3)
                {
                    oldDirX = _moveDirectionX;
                    oldDirY = _moveDirectionY;
                    _gridCoordinateY--;
                    _moveDirectionY = directions[directionIndex];
                    _moveDirectionX = 0;
                }

                if (_gridCoordinateY == 0||_gridCoordinateY==19||_gridCoordinateX == 0||_gridCoordinateX == 19 )
                {
                    GameActive = false;
                    gameOver = true;
                    
                    _gameOverScript.gameover(); 

                }
                
                else
                {
                    
                    oldPos = player.transform.position;
                    
                    player.transform.position = Grid.tiles[_gridCoordinateX, _gridCoordinateY];
                   
                       
                    _player.UpdatePosition(oldPos,oldDirX,oldDirY,_moveDirectionX,_moveDirectionY);
                        
                    
                    
                 
                    
                    
                }
                
                
                


                

                

                

            }
            
           
            yield return new WaitForSeconds(0.5f);
            buttonPushed = false;
        }

    }
}
