using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentAI : MonoBehaviour
{
    public int speed;
    public int range_detect;
    public Transform t1;
    public Transform t2;
    public Transform player;


    private Rigidbody2D rb;
    private int direction = 1;
    private int wait_a_ltl_bit=0;
    private float range = 0;
    private float player_pos = 0;
    private float enem_pos = 0;
    private bool facingRight = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        rb.velocity = new Vector2(direction * speed, rb.velocity.y);
        Detect_player();
        Check_colision_with_edge();
        if(facingRight==true && direction == -1)
        {
            Flip();
        }
        else if(facingRight==false && direction == 1)
        {
            Flip();
        }
    }

    void Check_colision_with_edge()
    {
        if(wait_a_ltl_bit==0)
        {
            if (transform.position.x <= t1.position.x || transform.position.x >= t2.position.x)
            {
                    direction *= -1;
                    wait_a_ltl_bit = 5;   
            }
        }
        else
        {
            if(wait_a_ltl_bit>0)
            {
                wait_a_ltl_bit--;
            }
        }
    }

    void Detect_player()
    {
        enem_pos = transform.position.x;
        player_pos = player.position.x;
        range = enem_pos - player_pos;

        if (player.position.x > t1.position.x && player.position.x < t2.position.x && player.position.y > transform.position.y - 3 && player.position.y < transform.position.y + 3)
        {
            if (range > 0)
            {
                if (range < range_detect)
                {
                    direction = -1;
                }
            }
            else if (range < 0)
            {
                if (Mathf.Abs(range) < range_detect)
                {
                    direction = 1;
                }
            }
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}
