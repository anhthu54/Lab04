using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    public float xMinMax;
    public float zMin;
    public GameObject rock;
    public int count;
    public float startWait;
    public float cloneWait;
    public float waveWait;

    private int score;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI restartText;
    public TextMeshProUGUI gameOverText;

    private bool gameOver;
    private bool restart;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        scoreText.text = "Score: 0";
        restartText.text = "";
        gameOverText.text = "";
        StartCoroutine(Waves());
    }

    IEnumerator Waves(){
        while(true){
        yield return new WaitForSeconds(startWait);
        for(int i =0; i<count;i++){
            Instantiate(rock,new Vector3(Random.Range(-xMinMax,xMinMax),0,zMin),Quaternion.identity);
            yield return new WaitForSeconds(cloneWait);
        }
      
        yield return new WaitForSeconds(waveWait);

        if(gameOver){
            restart = true;
            restartText.text = "Press R to restart";
            break;
        }
       
        }

    }
    // Update is called once per frame
    void Update()
    {
        if(restart && Input.GetKeyDown(KeyCode.R)){
            Application.LoadLevel(Application.loadedLevel);
        }
    }

    public void countScore(int sc){
        score+=sc;
        scoreText.text = "Score: "+score;
    }

    public void GameOver(){
        gameOverText.text ="Game Over!";
        gameOver = true;
    }
}
