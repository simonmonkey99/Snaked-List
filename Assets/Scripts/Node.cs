using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node<T>
{
    public Node<T> next;
    public T data;
    public int Y;
    public int X;

    public Node ( T d)
      {
          Y = 0;
          X = 0;
          next = null;
          data = d;
      }                              
  

  
        
       

      


    
}
