using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject sparklesVFX;
    [SerializeField] int maxHits;
    [SerializeField] Sprite[] hitSprites;

    Level level;
    GameStatus gameStatus;
    SpriteRenderer spriteRenderer;

    int timesHit;

    void Start()
    {
        level = FindObjectOfType<Level>();
        gameStatus = FindObjectOfType<GameStatus>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (tag == "Breakable") level.AddBlock();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag == "Breakable") {
            timesHit++;
            if (timesHit >= maxHits) HandleBlockDestroy();
            else spriteRenderer.sprite = hitSprites[timesHit - 1];
        }
    }

    void HandleBlockDestroy()
    {
        gameStatus.AddToScore();
        TriggerSparkles();
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
        Destroy(gameObject);
        level.RemoveBlock();
    }

    void TriggerSparkles()
    {
        GameObject sparkles = Instantiate(sparklesVFX, transform.position, transform.rotation);
        Destroy(sparkles, 2f);
    }
}
