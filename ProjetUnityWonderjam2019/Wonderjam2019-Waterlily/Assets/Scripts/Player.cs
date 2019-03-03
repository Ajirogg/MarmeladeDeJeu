using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float horizontal;
    float vertical;

    public float runSpeed = 10f;
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

  
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.E))
        {
            Use();
        }

        if (rigidbody.velocity.sqrMagnitude > 5)
        {
            angle = Mathf.Atan2(rigidbody.velocity.x, rigidbody.velocity.y) * Mathf.Rad2Deg;            
        }
        rigidbody.MoveRotation(-angle);

    }

    private void Use()
    {
        triggerUse.FirstObject().GetComponent<Utilisable>().Use();           
    }

    private void FixedUpdate()
    {
        Movement();
    }
    

    private void Movement()
    {

        rigidbody.velocity = new Vector2(Mathf.Lerp(0, Input.GetAxis("Horizontal") * runSpeed, 0.8f),
                                                 Mathf.Lerp(0, Input.GetAxis("Vertical") * runSpeed, 0.8f));


        


        // Vector2 velocity = new Vector2(horizontal * speed, vertical * speed);
        //rigidbody.velocity = velocity;



        //transform.rotation = Quaternion.LookRotation(previous-cur, Vector3.back);
        //velocity = previous - cur;


    }
}
