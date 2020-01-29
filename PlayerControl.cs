using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    #region Variaveis públicas
    public float walkSpeed;
    public float runSpeed;
    public bool running = false;
    #endregion

    #region Variaveis privadas
    Rigidbody rb;
    Vector3 moveDirection;
    #endregion

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Start()
    {

    }

    void OnCollisionStay (Collision col)
    {

    }

    void Update()
    {
        #region Input do usuário
        float horizontalMov = Input.GetAxis("Horizontal");
        float verticalMov = Input.GetAxis("Vertical");
        moveDirection = (horizontalMov * transform.right + verticalMov * transform.forward);
        if (Input.GetButton("Run"))
        {
            running = true;
        } else {
            running = false;
        }
        #endregion
    }

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        #region Movimentação
        if (!running)
        {
            rb.velocity = moveDirection * walkSpeed * Time.deltaTime;
        }
        else
        {
            rb.velocity = moveDirection * runSpeed * Time.deltaTime;
        }
        #endregion
    }
}
