using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Austronaut : MonoBehaviour
{
    public GM gm;
    public Rigidbody2D austronaut;
    public float impulseForceY;
    public float speed;
    public int Jumpleft = 2;
    public Vector3 inictialScale;

    void Start()
    {
        austronaut = gameObject.GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        Jump();
        Move();

        if (austronaut.position.y < -7)
        {
            gm.GameOver();
            Time.timeScale = 0;
        }
    }
    
    public void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Jumpleft > 0 && austronaut != null)
        {
            austronaut.AddForce(new Vector2(0, impulseForceY), ForceMode2D.Impulse);
            Jumpleft =  Jumpleft - 1;
        }
    }
    void Move()
    {
        austronaut.freezeRotation = true;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
        
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
    }

    void OnCollisionEnter2D(Collision2D collision){       
        if (collision.gameObject.name == "Ground") 
        {  
            Jumpleft = 2;
        }
        
        if (collision.gameObject.name == "Secoupe") 
        {
            Destroy(this.gameObject);
            gm.GameOver();
        }
        if (collision.gameObject.name == "Galaxy") 
        {
            Destroy(this.gameObject);
            gm.GameWin();
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Goodie"))
        {
            gm.AddPoints(collider);
            Destroy(collider.gameObject);
        }
    }
}