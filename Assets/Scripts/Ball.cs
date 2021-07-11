using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] Paddle paddle1;
    [SerializeField] float xPush = 2f;
    [SerializeField] float yPush = 15f;
    [SerializeField] AudioClip[] ballSounds;

    Vector2 paddleToBallVector;
    bool hasStarted = false;
    
    Rigidbody2D rb;
    AudioSource audioSource;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {
        paddleToBallVector = transform.position - paddle1.transform.position;    
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)
        {
            LockToPaddle();
            LaunchOnClick();
        }
    }

    void LockToPaddle()
    {
        var paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlePos + paddleToBallVector;
    }

    void LaunchOnClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            hasStarted = true;
            rb.velocity = new Vector2(xPush, yPush);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (hasStarted)
        {
            var clip = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)];
            audioSource.PlayOneShot(clip);
        }
    }
}
