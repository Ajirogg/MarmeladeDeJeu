using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float horizontal;
    float vertical;

    public float runSpeed = 20.0f;
    public float rotationSpeed = 1f;
    Vector3 hitPoint;
    new Rigidbody2D rigidbody;
    TriggerUse triggerUse;
    float angle;
    void Start()
    {
        rigidbody = this.GetComponent<Rigidbody2D>();
        triggerUse = this.transform.Find("TriggerUse").GetComponent<TriggerUse>();
        
    }

    public float speed = 5f;
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.E))
        {
            Use();
        }

    }

    private void Use()
    {
        HashSet<GameObject> utilisables = triggerUse.ObjetsUtilisables;
        
        foreach (GameObject u in utilisables)
        {

            print(u.GetType());
            u.GetComponent<Utilisable>().Use();
               
        }
           
    }

    private void FixedUpdate()
    {
        Movement();
    }
    

    private void Movement()
    {

        Vector2 velocity = new Vector2(horizontal * speed, vertical * speed);
        rigidbody.velocity = velocity;
        
        if(velocity != Vector2.zero)
        {
            angle = Mathf.Atan2(rigidbody.velocity.x, rigidbody.velocity.y) * Mathf.Rad2Deg;
        }
        rigidbody.MoveRotation(-angle);
    }
}
