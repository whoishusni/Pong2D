using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BallController : MonoBehaviour
{
    public int force;
    Rigidbody2D rigidbody;

    int scorePlayer1;
    int scorePlayer2;

    Text tampilScorePlayer1;
    Text tampilScorePlayer2;

    GameObject panelFinish;
    Text pemenangPermainan;

    AudioSource audioSource;

    public AudioClip efekBenturan;


    
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        Vector2 arah = new Vector2(2,0).normalized;
        rigidbody.AddForce(arah*force);

        scorePlayer1 = 0;
        scorePlayer2 = 0;

        tampilScorePlayer1 = GameObject.Find("scorePlayer1").GetComponent<Text>();
        tampilScorePlayer2 = GameObject.Find("scorePlayer2").GetComponent<Text>();

        panelFinish = GameObject.Find("panelFinish");
        panelFinish.SetActive(false);

        audioSource = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.name == "tepiKanan")
        {
            scorePlayer1 +=1;
            tampilkanScore();
            resetBall();
            Vector2 arah = new Vector2(2,0).normalized;
            rigidbody.AddForce(arah*force);
            if(scorePlayer1 == 5){
                panelFinish.SetActive(true);
                pemenangPermainan = GameObject.Find("textPemenang").GetComponent<Text>();
                pemenangPermainan.text = "Player 1 Menang";
                Destroy(gameObject);
                return;
            }

        }
        if(collision.gameObject.name == "tepiKiri")
        {
            scorePlayer2 += 1;
            tampilkanScore();
            resetBall();
            Vector2 arah = new Vector2(-2,0).normalized;
            rigidbody.AddForce(arah*force);
             if(scorePlayer2 == 5){
                panelFinish.SetActive(true);
                pemenangPermainan = GameObject.Find("textPemenang").GetComponent<Text>();
                pemenangPermainan.text = "Player 2 Menang";
                Destroy(gameObject);
                return;
            }
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
    void tampilkanScore()
    {
        tampilScorePlayer1.text = scorePlayer1 + "";
        tampilScorePlayer2.text = scorePlayer2 + "";
    }
}
