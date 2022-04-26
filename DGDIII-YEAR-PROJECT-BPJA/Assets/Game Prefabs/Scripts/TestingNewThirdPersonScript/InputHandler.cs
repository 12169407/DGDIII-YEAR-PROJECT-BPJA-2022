using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    public float horiz;
    public float vert;
    public float moveAmount;
    public float mouseX;
    public float mouseY;

    PlayerControls inputActions;

    Vector2 movementInput;
    Vector2 cameraInput;

    public void OnEnable()
    {
        if (inputActions == null)
        {
            inputActions = new PlayerControls();
            inputActions.PlayerMovement.Movement.performed += inputActions => movementInput = inputActions.ReadValue<Vector2>();
            inputActions.PlayerMovement.Movement.performed += inputActions => movementInput = inputActions.ReadValue<Vector2>();
            inputActions.PlayerMovement.Camera.performed += i => cameraInput = i.ReadValue<Vector2>();
        }
    }
     
    private void OnDisable()
    {
        inputActions.Disable();
    }

    public void TickInput(float delta)
    {
        MoveInput(delta);
    }

    private void MoveInput(float delta)
    {
        horiz = movementInput.x;
        vert = movementInput.y;
        moveAmount = Mathf.Clamp01(Mathf.Abs(horiz) + Mathf.Abs(vert));
        mouseX = cameraInput.x;
        mouseY = cameraInput.y;
    }
}
