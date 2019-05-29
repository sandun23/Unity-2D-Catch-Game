using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text scoreText;
    public int ballValue;

    private int score;

    public GameController gameController;
    


    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        UpdateScore();
    }

    private void OnTriggerEnter2D()
    {
        score += ballValue;
        gameController.timeLeft += 2.0f;
        UpdateScore();
    }

  

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bomb")
        {
            score -= ballValue * 2;
            gameController.timeLeft -= 0f;
            UpdateScore();
        }
       
        
    }
 


    void UpdateScore()
    {
        scoreText.text = " Score :\n" + score;
    }


}
