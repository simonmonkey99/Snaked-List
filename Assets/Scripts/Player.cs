using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using Unity.Mathematics;
using UnityEditor.Experimental;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
   public static LList<GameObject> listan = new LList<GameObject>();

   public int score=0;
    
   
   public GameObject player;
   [SerializeField] private GameObject prefab;
    
   [SerializeField] private Sprite tailY;
   [SerializeField] private Sprite tailX;
   [SerializeField] private Sprite turn1;
   [SerializeField] private Sprite turn2;
   [SerializeField] private Sprite turn3;
   [SerializeField] private Sprite turn4;

   
   
  [SerializeField] private FruitSpawner m_FruitSpawner;
  private GameOver _gameOverScript;
    

  
    void Awake()
    {
        
        _gameOverScript = GameObject.Find("Canvas").GetComponent<GameOver>();
       
    }
    

    private void OnDestroy()
    {
        //new reference to the linked list after a LoadScene method call
       listan = new LList<GameObject>();
    }

    public void UpdatePosition(Vector3 pos, int oldDirX, int oldDirY, int newDirX, int newDirY)
    {
        if(listan.count>0)
        {
        
            //directions
            int tempX;
            int tempY;
            int X;
            int Y;
      
            //positions
            Vector3 updatePos=pos;
            Vector3 tempPos;
            
            //update sprites
            Sprite tempSprite;
            Sprite updateSprite=null;
            Node<GameObject> node=listan.first;
            
            
            //Selecting the correct sprite based on the player direction
            updateSprite = selectSprite(oldDirX,oldDirY,newDirX,newDirY);
            
            
            //Linked List iteration
            while (node != null)
            {
            
                // Player collision with tail
                 if (node.data.transform.position == player.transform.position)
                 {
                    _gameOverScript.gameover();
                
                 }
                 //Push back tail sprite 
                 tempSprite = node.data.GetComponent<SpriteRenderer>().sprite;
                 node.data.GetComponent<SpriteRenderer>().sprite = updateSprite;
                 updateSprite = tempSprite;
            
            
                //Push back tail direction
                 tempX = node.X;
                 node.X = oldDirX;
                 X = tempX;
                 tempY = node.Y;
                 node.Y = oldDirX;
                 Y = tempY;
            
            
                //push back tail position
                 tempPos = node.data.transform.position;
                 node.data.transform.position = updatePos;
                 updatePos = tempPos;
            
            
            // selecting next element to update
                 node = node.next;
            }

        }  
        
    }
    

    Sprite selectSprite( int oldDirX, int oldDirY, int newDirX, int newDirY)
    {

        Sprite selectedSprite=null;
        
        //Selecting sprite for the 1st element in the linked list with regard to player direction
        
        if (newDirX==-1&&oldDirY==1 || newDirY==-1 &&oldDirX==1)
        {
            selectedSprite = turn1;

        }
        else if (newDirX==1 &oldDirY==1 || newDirY==-1 &&oldDirX==-1)
        {
            selectedSprite = turn2;

        }

        else if (newDirX==-1 && oldDirY==-1|| newDirY==1&& oldDirX==1)
        { 
            selectedSprite = turn3;
        }
        else if(newDirX==1&& oldDirY==-1 || newDirY==1 && oldDirX==-1)
        { 
            selectedSprite = turn4;
       
        }


        if (newDirX == 1 && oldDirX==1 ||
            newDirX == -1 && oldDirX==-1)

        {
            selectedSprite = tailX;
            
        }
        else if (newDirY==1 && oldDirY==1||
                 newDirY==-1&& oldDirY==-1)
        {
            selectedSprite = tailY;
               
        }
        return selectedSprite;
    }

   
    private void OnTriggerEnter2D(Collider2D other)
   { 
       // Monkey/Player eats banana
       if (other.CompareTag("Banana"))
       { 
           listan.addNode( Instantiate(prefab));
           
           m_FruitSpawner.Spawner();
           
           Destroy(other.gameObject);
           
           score++;
       }
   }
}
