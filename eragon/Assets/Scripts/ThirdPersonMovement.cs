using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    public CharacterController controller;
    public float moveSpeed = 5f;
    public float rotationSpeed = 300f;

    public void Move()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 moveDirection = new Vector3(horizontal, 0f, vertical).normalized;

        Vector3 projectedCameraForward = Vector3.ProjectOnPlane(Camera.main.transform.forward, Vector3.up);
        Quaternion rotationToCamera = Quaternion.LookRotation(projectedCameraForward, Vector3.up);

        moveDirection = rotationToCamera * moveDirection;
        Quaternion rotationToMove = Quaternion.LookRotation(moveDirection, Vector3.up);

        if (moveDirection.magnitude > 0)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotationToMove, rotationSpeed * Time.deltaTime);
        }

        controller.Move(moveDirection * moveSpeed * Time.deltaTime);
    }

    void Update()
    {
        Move();
    }

}
