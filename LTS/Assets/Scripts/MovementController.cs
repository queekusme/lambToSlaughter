using UnityEngine;
using System.Collections;

public class MovementController : MonoBehaviour
{


    public float maxSpeed = 10.0f;
    private bool facingRight = true;

    private bool onGround; // jumping

    // Use this for initialization
    void Start() { }

    // Update is called once per frame
    void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        if ((facingRight && x < 0.0f) || (!facingRight && x > 0.0f)) { flip(); }

        if (onGround && y > 0)
        {
            onGround = false;
        }

        GetComponent<Rigidbody2D>().velocity = new Vector2(x * maxSpeed, GetComponent<Rigidbody2D>().velocity.y);
        Debug.Log(x);
    }


    void flip()
    {
        GetComponentInChildren<SpriteRenderer>().flipX = !GetComponentInChildren<SpriteRenderer>().flipX;
        facingRight = !facingRight;
    }
}