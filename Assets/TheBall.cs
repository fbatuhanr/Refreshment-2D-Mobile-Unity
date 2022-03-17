using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheBall : MonoBehaviour
{
    [HideInInspector] public int playerPoint; 
    private Rigidbody2D rb;
    void Start()
    {
        playerPoint = 0;
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate() {
        
        if(Input.GetKeyDown(KeyCode.Space)){
             rb.velocity = Vector2.zero;
        }

        if(Input.GetKey(KeyCode.UpArrow)){
            rb.velocity = Vector2.zero;
            rb.AddForce(Vector2.up*175);
        }
        if(Input.GetKey(KeyCode.RightArrow)){
            rb.velocity = Vector2.zero;
            rb.AddForce(Vector2.right*175);
        }
        if(Input.GetKey(KeyCode.DownArrow)){
            rb.velocity = Vector2.zero;
            rb.AddForce(Vector2.down*175);
        }
        if(Input.GetKey(KeyCode.LeftArrow)){
            rb.velocity = Vector2.zero;
            rb.AddForce(Vector2.left*175);
        }
    }


    private void OnCollisionEnter2D(Collision2D other) {

        if(other.transform.parent.name == "CornersParent"){

           // GetComponent<AudioSource>().Play(0);
        }
    }


}
