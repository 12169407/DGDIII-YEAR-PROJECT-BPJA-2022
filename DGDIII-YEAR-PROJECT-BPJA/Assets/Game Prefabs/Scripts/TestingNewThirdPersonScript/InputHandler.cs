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

    Vector2 moveInput;
    Vector2 camInput;

    public void OnEnable()
    {
        if (inputActions == null)
        {
            inputActions = new PlayerControls();
            inputActions.PlayerMovement.Movement.performed += inputActions => moveInput = inputActions.ReadValue<Vector2>();
            inputActions.PlayerMovement.Camera.performed += i => camInput = i.ReadValue<Vector2>();
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
        horiz = moveInput.x;
        vert = moveInput.y;
        moveAmount = Mathf.Clamp01(Mathf.Abs(horiz) + Mathf.Abs(vert));
        mouseX = camInput.x;
        mouseY = camInput.y;
    }
}
