using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float screenWidthInUnits = 16f;
    [SerializeField] float minX = 0;
    [SerializeField] float maxX = 16;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        var newHorizontalPos = Input.mousePosition.x / Screen.width * screenWidthInUnits;
        var paddlePos = new Vector2(transform.position.x, transform.position.y);
        var paddleWidth = GetComponent<SpriteRenderer>().bounds.size.x;
        paddlePos.x = Mathf.Clamp(newHorizontalPos, minX + (paddleWidth / 2), maxX - (paddleWidth / 2));
        transform.position = paddlePos;
    }
}
