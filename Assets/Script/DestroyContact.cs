using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyContact : MonoBehaviour
{
    public GameObject rockExplosion;
    public GameObject playerExplosion;
    private GameController gameController;

    public int score;

    // Start is called before the first frame update
    void Start()
    {
        GameObject controller = GameObject.FindWithTag("GameController");
        if(controller!=null){
            gameController = controller.GetComponent<GameController>(); 
        }
        if(gameController == null){
            Debug.Log("error");
        }
    }

    void OnTriggerEnter(Collider other){
        if(other.tag == "Boundary"){
            return;
        }
            Instantiate(rockExplosion, transform.position,transform.rotation);
            if(other.tag == "Player"){
                Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
                gameController.GameOver();
            }
            gameController.countScore(score);
            Destroy(other.gameObject);
            Destroy(gameObject);
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
