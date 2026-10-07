using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementTest : MonoBehaviour
{
//movement var
    public float moveSpeed = 4f;
    public float running = 9f;
    private float currentSpeed; 

    private PlayerAttackUpdate attackScr;

//anim var
    Animator thisAnim;
    float lastX, lastY;

    void Start()
    {
        thisAnim = GetComponent<Animator>();
        attackScr = GetComponent<PlayerAttackUpdate>();
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        Vector3 rightMovement = Vector3.right * moveSpeed * Time.deltaTime * Input.GetAxis("Horizontal");
        Vector3 upMovement = Vector3.up * moveSpeed * Time.deltaTime * Input.GetAxis("Vertical");
    
        Vector3 heading = Vector3.Normalize(rightMovement + upMovement);

        transform.position += rightMovement;
        transform.position += upMovement;

        UpdateAnimation(heading);
    }

    void UpdateAnimation(Vector3 dir) 
    {
        if (attackScr.isAttacking)
        {
            return;
        }

        print("bmalf");

        if(dir.x == 0f && dir.y == 0f)
        {
            //if we are idle, execute idle anim
            thisAnim.SetFloat("DirX", lastX);
            thisAnim.SetFloat("DirY", lastY);
            thisAnim.SetBool("Movement", false);
        } 
        else 
        {
            
            thisAnim.SetFloat("DirX", dir.x);
            thisAnim.SetFloat("DirY", dir.y);

            //thisAnim.SetFloat("LastDirX", dir.x);
            //thisAnim.SetFloat("LastDirY", dir.y);

            lastY = dir.x;
            lastY = dir.y;

            thisAnim.SetBool("Movement", true);
        }

        
    }
}