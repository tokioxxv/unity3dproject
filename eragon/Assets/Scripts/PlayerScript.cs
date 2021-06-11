using System.Collections;
using System.Collections.Generic;
using Microsoft.VisualBasic;
using UnityEngine;




public class PlayerScript : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;




    private void MovementHandler(float speed){ 
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.transform.eulerAngles.y;
            // float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * Time.deltaTime * speed);
        }
    }









    void Update()
    {
       MovementHandler(60f);
    }

}
