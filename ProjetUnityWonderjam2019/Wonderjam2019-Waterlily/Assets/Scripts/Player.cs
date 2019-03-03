using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float horizontal;
    float vertical;
    public int indice;

    public float runSpeed = 10f;
    public float rotationSpeed = 1f;
    Vector3 hitPoint;
    new Rigidbody2D rigidbody;
    TriggerUse triggerUse;
    float angle;

    public bool talking = false;


    void Start()
    {
        rigidbody = this.GetComponent<Rigidbody2D>();
        triggerUse = this.transform.Find("TriggerUse").GetComponent<TriggerUse>();

    }


    void Update()
    {
        if (!talking)
        {
            horizontal = Input.GetAxis("Horizontal");
            vertical = Input.GetAxis("Vertical");

            if (Input.GetKeyDown(KeyCode.Return))
            {
                talking = Use();
            }

            if (rigidbody.velocity.sqrMagnitude > 5)
            {
                angle = Mathf.Atan2(rigidbody.velocity.x, rigidbody.velocity.y) * Mathf.Rad2Deg;
            }
            rigidbody.MoveRotation(-angle);
        }

        else
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                Answer();
            }

        }


    }

    private bool Use()
    {
        if (triggerUse.FirstObject() == null)
            return false;
        return triggerUse.FirstObject().GetComponent<Utilisable>().Use();
    }

    private void Answer()
    {
        bool bonneReponse;
        GameObject.FindGameObjectWithTag("Question").GetComponent<QuestionManager>().Reponse(out indice, out bonneReponse);
        print(indice);

        GameObject.Find("GameManager").GetComponent<GameManager>().appliquerReponse(indice);



        talking = !bonneReponse;
    }

    private void FixedUpdate()
    {
        Movement();
        rigidbody.MoveRotation((-(int)angle / 90)*90);
    }


    private void Movement()
    {

        rigidbody.velocity = new Vector2(Mathf.Lerp(0,horizontal * runSpeed, 0.8f),
                                                 Mathf.Lerp(0, vertical * runSpeed, 0.8f));





        // Vector2 velocity = new Vector2(horizontal * speed, vertical * speed);
        //rigidbody.velocity = velocity;



        //transform.rotation = Quaternion.LookRotation(previous-cur, Vector3.back);
        //velocity = previous - cur;


    }
}
