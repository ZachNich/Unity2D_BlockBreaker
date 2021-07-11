using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip breakSound;
    Level level;
    GameStatus gameStatus;

    void Start()
    {
        level = FindObjectOfType<Level>();
        gameStatus = FindObjectOfType<GameStatus>();
        level.AddBlock();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        HandleBlockHit();
    }

    void HandleBlockHit()
    {
        gameStatus.AddToScore();
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
        Destroy(gameObject);
        level.RemoveBlock();
    }
}
