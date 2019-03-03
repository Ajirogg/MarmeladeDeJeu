using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float horizontal;
    float vertical;
    Vector2 movementInput;
    public int indice;

    public float runSpeed = 5f;
    public float rotationSpeed = 1f;
    Vector3 hitPoint;
    new Rigidbody2D rigidbody;
    TriggerUse triggerUse;
    float angle;
    Utilisable isTalkingTo;

    public bool talking = false;

    public Animator playerAnimator;

    void Start()
    {
        rigidbody = this.GetComponent<Rigidbody2D>();
        triggerUse = this.transform.Find("TriggerUse").GetComponent<TriggerUse>();
        playerAnimator = this.GetComponentInChildren<Animator>();
    }


    void Update()
    {
        if (!talking)
        {
            horizontal = Input.GetAxis("Horizontal");
            vertical = Input.GetAxis("Vertical");
            movementInput = new Vector2(horizontal, vertical);

            if (movementInput.magnitude > 1f)
                movementInput = movementInput.normalized;


            if (Input.GetKeyDown(KeyCode.Return))
            {
                talking = Use();
            }

            if (rigidbody.velocity.sqrMagnitude > 1)
            {
                angle = Mathf.Atan2(movementInput.x, movementInput.y) * Mathf.Rad2Deg;
            }
        }

        else
        {
            movementInput = Vector2.zero;
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
        isTalkingTo = triggerUse.FirstObject().GetComponent<Utilisable>() ;
        return triggerUse.FirstObject().GetComponent<Utilisable>().Use();
    }

    private void Answer()
    {
        bool bonneReponse;
        GameObject.FindGameObjectWithTag("Question").GetComponent<QuestionManager>().Reponse(out indice, out bonneReponse);
        //print(indice);
        GameObject.Find("GameManager").GetComponent<GameManager>().appliquerReponse(indice, isTalkingTo);

        talking = !bonneReponse;
    }

    private void FixedUpdate()
    {
        Movement();
        rigidbody.MoveRotation(-(int)angle);
    }


    private void Movement()
    {

        rigidbody.velocity = new Vector2(movementInput.x * runSpeed, movementInput.y * runSpeed);

        playerAnimator.SetFloat("Speed", rigidbody.velocity.magnitude);






        // Vector2 velocity = new Vector2(horizontal * speed, vertical * speed);
        //rigidbody.velocity = velocity;



        //transform.rotation = Quaternion.LookRotation(previous-cur, Vector3.back);
        //velocity = previous - cur;


    }
}
