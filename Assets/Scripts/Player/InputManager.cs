using System.Collections;
using UnityEngine;
#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif

namespace LuciferGamingStudio
{
    public class InputManager : MonoBehaviour
    {
        public static InputManager Instance;

        [Header("Input Manager")]
        public bool canMove = true;
        public bool CanMove { get; set; }

        [Header("Character Input Values")]
        public Vector2 move;
        public Vector2 look;
        public bool sprint;
        public bool interact;

        [Header("Movement Settings")]
        public bool analogMovement;

        [Header("Mouse Cursor Settings")]
        public bool cursorLocked = true;
        public bool cursorInputForLook = true;

        private void Awake()
        {
            Instance = this;
        }

#if ENABLE_INPUT_SYSTEM
        public void OnMove(InputValue value)
        {
            if (canMove)
                MoveInput(value.Get<Vector2>());
            else
                move = Vector2.zero;
        }

        public void OnLook(InputValue value)
        {
            if (cursorInputForLook && canMove)
                LookInput(value.Get<Vector2>());
            else
                look = Vector2.zero;
        }

        public void OnSprint(InputValue value)
        {
            SprintInput(value.isPressed);
        }

        public void OnInteract(InputValue value)
        {
            interact = value.isPressed;
        }
#endif


        public void MoveInput(Vector2 newMoveDirection)
        {
            move = newMoveDirection;
        }

        public void LookInput(Vector2 newLookDirection)
        {
            look = newLookDirection;
        }

        public void SprintInput(bool newSprintState)
        {
            sprint = newSprintState;
        }

        private void OnApplicationFocus(bool hasFocus)
        {
            SetCursorState(cursorLocked);
        }

        public void SetCursorState(bool newState)
        {
            Cursor.lockState = newState ? CursorLockMode.Locked : CursorLockMode.None;
        }

        public void SetCanMove(bool canMove)
        {
            this.canMove = canMove;
        }
    }

}