using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LList<T>
{
    public Node<T> first;
    public Node<T> last;
    public int count { get; private set; }
  public LList()
    {
        first = null;
        last = null;
        count = 0;
    }

  public void addNode(T data)
    {
        count++;
        Node<T> node = new Node<T>(data);
        if (first == null)
        {
          
            first = node;
            last = node;
        }
        else
        {
            last.next = node;
            last = node;
            
        }

    }
}
