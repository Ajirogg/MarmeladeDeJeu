using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float horizontal;
    float vertical;

    public float runSpeed = 20.0f;
    public float rotationSpeed = 1f;
    Vector3 hitPoint;
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
        Movement();




    }
    

    private void Movement()
    {
        rigidbody.velocity = new Vector2(horizontal * speed, vertical * speed);

        if (rigidbody.velocity != Vector2.zero)
        {
            float angle = Mathf.Atan2(rigidbody.velocity.x, rigidbody.velocity.y) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.back);
        }
    }
}
