using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("Cherry"))
        {
            CherryCollectot.cherryCount += 1;
            Destroy(other.gameObject);
        }
    }
}
