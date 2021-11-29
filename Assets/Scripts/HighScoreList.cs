using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreList : MonoBehaviour
{
    
    public static List<int> score=new List<int>();
    public static List<string> PlayerName=new List<string>();

    public Text[] Pscore= new Text[5];
   
    public Text[] name=new Text[5];
    

    private void Update()
    {
        
        for (int i = 0; i < PlayerName.Count; i++)

        {
            Pscore[i].text=score[i].ToString();
            name[i].text = PlayerName[i];

            
        }
        
    }

    //sorts the highscore list  
    public void addScore(int points, string player)
    {

        int temp;
        int j = 0;
        string strtemp;
        
        
      
       
            while (j <= score.Count)
            {
                if (j != score.Count)
                {
                    if (points >= score[j])
                    { 
                        temp = score[j];
                        score[j] = points;
                        points = temp;


                        strtemp = PlayerName[j];
                        PlayerName[j] = player;
                        player = strtemp;
                    }
                }
                
                if (j == score.Count&&score.Count<5)
                {
                        
                    score.Add(points);
                    PlayerName.Add(player);
                    break;
                }
                j++;   
                   
            }
            
        
        
        
       

        
 
    }
}
