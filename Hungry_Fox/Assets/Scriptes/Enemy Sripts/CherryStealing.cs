using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CherryStealing : MonoBehaviour
{
    public int steal;
    public PlayerMove move;
    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            CherryCollectot.CherrySteal(steal);
            if(other.transform.position.x <= transform.position.x)
            {
                move.knockFromRight = true;
            }
            else if(other.transform.position.y > transform.position.x)
            {
                move.knockFromRight = false;
            }
            move.KBTimer = move.KBTotalTime;
        }
    }
}
