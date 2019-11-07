using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public float kecepatan;
    public string axis;

    public float batasAtas;
    public float batasBawah;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float gerak = Input.GetAxis(axis) * kecepatan * Time.deltaTime;
        float nextPosition = transform.position.y + gerak;

        if(nextPosition>batasAtas){
            gerak = 0;
        }
        if(nextPosition<batasBawah){
            gerak = 0;
        }
        //nilai x,y,z
        transform.Translate(0,gerak,0);
        
    }
}
