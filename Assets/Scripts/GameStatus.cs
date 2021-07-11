using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStatus : MonoBehaviour
{
    [Range(0.1f, 10f)] [SerializeField] float gameSpeed = 1f;
    [SerializeField] int pointsPerBlockDestroyed = 69;
    [SerializeField] int currScore = 0; 
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] bool isAutoPlaying;

    void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameStatus>().Length;
        if (gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        scoreText.text = currScore.ToString();
    }
    
    // Update is called once per frame
    void Update()
    {
        Time.timeScale = gameSpeed;    
    }

    public void AddToScore()
    {
        currScore += pointsPerBlockDestroyed;
        scoreText.text = currScore.ToString();
    }

    public void ResetGame()
    {
        Destroy(gameObject);
    }

    public bool IsAutoPlaying()
    {
        return isAutoPlaying;
    }
}
