using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Camera cam;
    public Renderer renderer;
    private float maxWidth;
    private bool playing;

    public float timeLeft;
    public Text timerText;
    

    
    public GameObject[] diamonds;

    public GameObject gameOverText;
    public GameObject restartButton;
    public GameObject startButton;
    public ShipScript shipScript;
    

    // Start is called before the first frame update
    void Start()
    {
        renderer = diamonds[0].GetComponent<Renderer>(); 

        if (cam == null)
        {
            cam = Camera.main;
        }
         


        playing = false;
        Vector3 upperCorner = new Vector3(Screen.width, Screen.height, 0.0f);
        Vector3 targetWidth = cam.ScreenToWorldPoint(upperCorner);
        float diamondWidth =renderer.bounds.extents.x;
        maxWidth = targetWidth.x - diamondWidth;
        UpdateText();

    }

    private void FixedUpdate()
    {
        if (playing) { 
        timeLeft -= Time.deltaTime;
        if(timeLeft < 0)
        {
            timeLeft = 0;
        }
           
        UpdateText();
            
        }
    }

  
    public void StartGame()
    {
       
        startButton.SetActive(false);
        shipScript.ToggleControl(true);
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn ()
    {
        yield return new WaitForSeconds(2.0f);
        playing = true;
        while (timeLeft > 0) {
            GameObject diamond = diamonds[Random.Range(0, diamonds.Length)];
                 Vector3 spawnPosition = new Vector3(
                    Random.Range(-maxWidth, maxWidth),
                    transform.position.y,
                    0.0f           
                );
                Quaternion spawnRoation = Quaternion.identity;
                Instantiate (diamond, spawnPosition, spawnRoation);
            yield return new WaitForSeconds(Random.Range(1.5f, 2.5f));
        }
        yield return new WaitForSeconds(1.0f);
        gameOverText.SetActive(true);


        yield return new WaitForSeconds(1.5f); 
        restartButton.SetActive(true);
    }

    void UpdateText()
    {
        timerText.text = "Time Left: \n" + Mathf.RoundToInt(timeLeft);
    }
}