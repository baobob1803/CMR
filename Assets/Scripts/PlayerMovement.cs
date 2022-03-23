using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rgb2Dref;
    [HideInInspector] public float inputValueUp;
    [HideInInspector] public float inputValueSide;

    [Range(0, 15)] public float movementSpeed;

    void FixedUpdate()
    {
        Move();
    }

    public void MovementInputPressed(InputAction.CallbackContext ctx)
    {
        inputValueUp = ctx.ReadValue<Vector2>().x;
        inputValueSide = ctx.ReadValue<Vector2>().y;
    }

    public void Move()
    {
        if (!(inputValueUp == 0 && inputValueSide == 0))
        {
            rgb2Dref.velocity = new Vector2(inputValueUp * movementSpeed, inputValueSide * movementSpeed);
        }
        else
        {
            rgb2Dref.velocity = new Vector2(0, 0);
        }
    }


    public void PauseInputPressed(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            GameMaster.instGameMaster.ManagePause();
        }
    }

}
