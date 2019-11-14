using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class PengaturScene : MonoBehaviour
{
    public bool isExit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Escape)){
            if(isExit){
                Application.Quit();
            }
            else{
                quitGame();
            }
        }
        
    }
    public void mulaiGame(){
        SceneManager.LoadScene("Main");
    }
    public void quitGame(){
        SceneManager.LoadScene("SceneHalaman");
    }
}
