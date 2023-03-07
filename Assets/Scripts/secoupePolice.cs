using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class secoupePolice : MonoBehaviour
{
    public Rigidbody2D secoupe;
    public float speed; 
    public float moveRange;
    private float startXPos;

    void Start()
    {
        secoupe = gameObject.GetComponent<Rigidbody2D>();
        startXPos = transform.position.x;
    }

    void Update()
    {
        float moveAmount = Mathf.PingPong(Time.time * speed, moveRange * 2) - moveRange;
        transform.position = new Vector2(startXPos + moveAmount, transform.position.y);
        secoupe.freezeRotation = true;
    }
}


