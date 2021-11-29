using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Grid : MonoBehaviour
{
    private Camera cam;
    public GameObject dot;
    public GameObject wall;
    public static Vector3[,] tiles = new Vector3[20, 20];
    private float width;
    private float height;

    void Awake()
    {
      
        cam = Camera.main;
        
    Vector3 screenToWorldPointBL;
    screenToWorldPointBL = cam.ScreenToWorldPoint(new Vector3(0, 0));
    Vector3 screenToWorldPointBR = cam.ScreenToWorldPoint(new Vector3(cam.pixelWidth, 0));

    Vector3 screenToWorldPointTL = cam.ScreenToWorldPoint(new Vector3(0, cam.pixelHeight));



   
  

     float distanceX=Vector3.Distance(screenToWorldPointBL , screenToWorldPointBR);
     
     
     
     
     
     float distancey=Vector3.Distance(screenToWorldPointBL , screenToWorldPointTL);







    width = distanceX;
    height = distancey;

    
        
        
        
  


    //Point in center of Tile

    float tileHeight = height / 20;
    float centerY = screenToWorldPointBL.y + tileHeight / 2;
    
    
    float tileWidth = width / 20;
    float centerX = screenToWorldPointBL.x+tileWidth / 2;

   

        for (int y = 0; y< 20; y++)
    {



        for (int x = 0; x < 20; x++)
        {

            


            tiles[x, y] = new Vector3(centerX, centerY);
            if (x == 0 || x == 19 || y == 0 || y == 19)
            {
                
                Instantiate(wall,tiles[x,y],quaternion.identity);
            }
            else
            {
                Instantiate(dot,tiles[x,y],quaternion.identity);
            }
         
            
            
            
            centerX +=tileWidth ;

        }
        centerY += tileHeight;
        centerX = screenToWorldPointBL.x+tileWidth/2;
    }

        
}



}