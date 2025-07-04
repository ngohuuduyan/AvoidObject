using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int score; 
    public static GameManager instance;

    [SerializeField] TMP_Text scoreText;

    [SerializeField] PlayerMoving playerMoving;
    public void IncrementScore()
    {
        score++;
        scoreText.text = "Score: " + score.ToString();
        //Increase the player's speed
        playerMoving.speed += playerMoving.speedIncreasePerPoint;
    } 
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
