using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float playerSpeed;
    public float rotationSpeed;
    public Transform playerCamera;
    Vector3 speed = Vector3.zero;
    Vector3 rotation = Vector3.zero;

    public Animator playerAnimator;
    bool isWalk;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Rotation();
        playerCamera.transform.position = transform.position;

    }

    void Move()
    {
        speed = Vector3.zero;
        rotation = Vector3.zero;
        isWalk = false;

        if (Input.GetKey(KeyCode.W))
        {
            rotation.y = 0;
            MoveSet();
        }
        if (Input.GetKey(KeyCode.S))
        {
            rotation.y = 180;
            MoveSet();
        }
        if (Input.GetKey(KeyCode.A))
        {
            rotation.y = -90;
            MoveSet();
        }
        if (Input.GetKey(KeyCode.D))
        {
            rotation.y = 90;
            MoveSet();
            
        }
        transform.Translate(speed);
        playerAnimator.SetBool("walk", isWalk);
    }

    void MoveSet()
        {
            speed.z = playerSpeed;
            transform.eulerAngles = playerCamera.transform.eulerAngles + rotation;
            isWalk = true;
        }


    void Rotation()
        {
            var speed = Vector3.zero;
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                speed.y = -rotationSpeed;
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                speed.y = rotationSpeed;
            }
            playerCamera.transform.eulerAngles += speed;
        }

    }

