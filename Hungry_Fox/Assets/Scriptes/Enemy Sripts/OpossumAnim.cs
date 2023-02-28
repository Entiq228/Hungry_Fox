using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpossumAnim : MonoBehaviour
{
    private Animator anim;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            anim.Play("OpossumDeath");
            Destroy(gameObject, 0.3f);
        }
    }
}
