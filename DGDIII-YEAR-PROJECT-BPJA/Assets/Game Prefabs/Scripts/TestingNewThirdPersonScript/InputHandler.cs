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

<<<<<<< Updated upstream
    Vector2 moveInput;
    Vector2 camInput;
=======
    Vector2 movementInput;
    Vector2 cameraInput;
>>>>>>> Stashed changes

    public void OnEnable()
    {
        if (inputActions == null)
        {
            inputActions = new PlayerControls();
<<<<<<< Updated upstream
            inputActions.PlayerMovement.Movement.performed += inputActions => moveInput = inputActions.ReadValue<Vector2>();
            inputActions.PlayerMovement.Camera.performed += i => camInput = i.ReadValue<Vector2>();
=======
            inputActions.PlayerMovement.Movement.performed += inputActions => movementInput = inputActions.ReadValue<Vector2>();
            inputActions.PlayerMovement.Camera.performed += i => cameraInput = i.ReadValue<Vector2>();
>>>>>>> Stashed changes
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
<<<<<<< Updated upstream
        horiz = moveInput.x;
        vert = moveInput.y;
        moveAmount = Mathf.Clamp01(Mathf.Abs(horiz) + Mathf.Abs(vert));
        mouseX = camInput.x;
        mouseY = camInput.y;
=======
        horiz = movementInput.x;
        vert = movementInput.y;
        moveAmount = Mathf.Clamp01(Mathf.Abs(horiz) + Mathf.Abs(vert));
        mouseX = cameraInput.x;
        mouseY = cameraInput.y;
>>>>>>> Stashed changes
    }
}
