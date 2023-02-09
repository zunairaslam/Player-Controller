using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    public float horizontal;
    public float vertical;
    public float moveAmount;
    public float mouseX;
    public float mouseY;

    CameraFollow CameraFollow;

    private void Awake()
    {
        CameraFollow = CameraFollow.instance;
    }
    private void FixedUpdate()
    {
        float delta = Time.fixedDeltaTime;

        if (CameraFollow != null)
        {
            CameraFollow.FollowTarget(delta);
            CameraFollow.HandlerCmaeraRotation(delta, mouseX, mouseY);
        }
    }

    private void MoveInput(float delta)
    {
        horizontal= Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        moveAmount = Mathf.Clamp01(Mathf.Abs(horizontal) + Mathf.Abs(vertical));
        mouseX = Input.GetAxis("Mouse X");
        mouseY = -(Input.GetAxis("Mouse Y"));

    }

    public void TickInput(float delta)
    {
        MoveInput(delta);
    }

}
