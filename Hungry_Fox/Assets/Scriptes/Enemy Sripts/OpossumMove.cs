using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpossumMove : MonoBehaviour
{
    [SerializeField] private Transform[] transformPoints;
    [SerializeField] private int controlPoints;
    [SerializeField] private float speed;
    private bool facingRight = true;

    public void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, transformPoints[controlPoints].position, speed * Time.fixedDeltaTime);
        if (Vector2.Distance(transform.position, transformPoints[controlPoints].position) < 0.25f)
        {
            if (controlPoints > 0)
            {
                controlPoints = 0;
                Flip();
            }
            else
            {
                controlPoints = 1;
                Flip();
            }
        }
    }

    public void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}
