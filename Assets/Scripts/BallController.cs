using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public int force;
    Rigidbody2D rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        Vector2 arah = new Vector2(2,0).normalized;
        rigidbody.AddForce(arah*force);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.name == "tepiKanan")
        {
            resetBall();
            Vector2 arah = new Vector2(2,0).normalized;
            rigidbody.AddForce(arah*force);
        }
        if(collision.gameObject.name == "tepiKiri")
        {
            resetBall();
            Vector2 arah = new Vector2(-2,0).normalized;
            rigidbody.AddForce(arah*force);
        }
        if(collision.gameObject.name == "paddle1" || collision.gameObject.name == "paddle2")
        {
            float sudut = (transform.position.y - collision.transform.position.y) *5f;
            Vector2 arah = new Vector2(rigidbody.velocity.x,sudut).normalized;
            rigidbody.velocity = new Vector2(0,0);
            rigidbody.AddForce(arah*force*2);
        }
    }


    void resetBall()
    {
        transform.localPosition = new Vector2(0,0);
        rigidbody.velocity = new Vector2(0,0);
    }
}
