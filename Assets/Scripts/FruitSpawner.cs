using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;



public class FruitSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject banana;
    private movement _movementScript;
    
    void Start()
    {
        _movementScript = GameObject.Find("Player").GetComponent<movement>();
        Instantiate(banana, Grid.tiles[8, 8], quaternion.identity);
       
    }

    
//spawn bananas randomly within the playable area
    public void Spawner()
    {
        if (_movementScript.GameActive==true)
        {
            int BananaX=1;
            int BananaY=1;
            bool success=false; 
            
            
            while(!success) 
            {
                Node<GameObject> node = Player.listan.first; 
                BananaX = Random.Range(1, 19);
                BananaY = Random.Range(1, 19);
                
                // avoid spawning bananas on the tails
                for (int i = 0; i < Player.listan.count; i++)
                { 
                    
                    if (Grid.tiles[BananaX, BananaY] == node.data.transform.position) { break; }
                 
                   if(node==Player.listan.last) { success = true;  }
                   
                        node = node.next;
                    
                    
                    
                    
                }
            }
            Instantiate(banana, Grid.tiles[BananaX, BananaY], quaternion.identity);
        }

    }
}
