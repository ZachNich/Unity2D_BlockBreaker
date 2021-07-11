using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float screenWidthInUnits = 16f;
    [SerializeField] float minX = 0;
    [SerializeField] float maxX = 16;

    GameStatus gameStatus;
    Ball ball;
    SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        gameStatus = FindObjectOfType<GameStatus>();
        ball = FindObjectOfType<Ball>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        var paddlePos = new Vector2(transform.position.x, transform.position.y);
        var paddleWidth = spriteRenderer.bounds.size.x;
        paddlePos.x = Mathf.Clamp(GetXPos(), minX + (paddleWidth / 2), maxX - (paddleWidth / 2));
        transform.position = paddlePos;
    }

    float GetXPos()
    {
        if (gameStatus.IsAutoPlaying()) return ball.transform.position.x;
        else return Input.mousePosition.x / Screen.width * screenWidthInUnits;
    }
}
