using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float horizontal;
    float vertical;

    public float runSpeed = 20.0f;
    Rigidbody2D rigidbody;

    void Start()
    {
        rigidbody = this.GetComponent<Rigidbody2D>();
    }

    public float speed = 5f;
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        
    }

    private void FixedUpdate()
    {

        rigidbody.velocity = new Vector2(horizontal * speed, vertical * speed);
    }

}
