using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision_with_opponent : MonoBehaviour
{
    private Rigidbody2D rb;
    private int how_many_opponents=4;
    private float HitForce = 35;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        for(int i=1; i<=how_many_opponents; i++)
        {
            if (collision.gameObject.name == "Opponent_Mace_" + i.ToString())
            {
                rb.velocity = new Vector2();
                rb.velocity = Vector2.up * HitForce;
            }
        }
    }
}
