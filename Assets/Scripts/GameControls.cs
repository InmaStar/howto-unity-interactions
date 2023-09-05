using System.Runtime.CompilerServices;
using UnityEngine;

    public static class GameControls
    {
        //TODO replace by Rewired, New InputSystem or something like that
        
        private const string ACTION_MOVE_HORIZONTAL = "Move Horizontal";
        private const string ACTION_MOVE_VERTICAL = "Move Vertical";
        private const string ACTION_RUN = "Run";
        private const string ACTION_INTERACT = "Interact";
        private const string ACTION_PAUSE = "Pause";

        private const string UI_ACTION_MOVE_HORIZONTAL = "UiHorizontal";
        private const string UI_ACTION_MOVE_VERTICAL = "UiVertical";
        
        private const string UI_ACTION_CONFIRM = "UiConfirm";
        private const string UI_ACTION_CANCEL = "UiCancel";

        // Character controls
        public static int GetHorizontalMove()
        {
            if (IsKeyHeld(KeyCode.D) || IsKeyHeld(KeyCode.RightArrow)) // Right
                return 1;
            if (IsKeyHeld(KeyCode.A) || IsKeyHeld(KeyCode.LeftArrow)) //Left
                return -1;

            return 0;
        }

        public static int GetVerticalMove()
        {
            if (IsKeyHeld(KeyCode.W) || IsKeyHeld(KeyCode.UpArrow)) // Up
                return 1;
            if (IsKeyHeld(KeyCode.S) || IsKeyHeld(KeyCode.DownArrow)) // Down
                return -1;

            return 0;
        }

        public static bool IsInteractPressed()
        {
            return IsKeyPressed(KeyCode.E);
        }

        public static bool IsRunHeld()
        {
            return IsKeyHeld(KeyCode.Space) || IsKeyHeld(KeyCode.Tab);
        }        
        
        public static bool IsRunPressed()
        {
            return IsKeyPressed(KeyCode.Tab);
        }
        
        public static bool IsPausePressed()
        {
            return IsKeyHeld(KeyCode.P) || IsKeyHeld(KeyCode.Escape);
        }
        
        // UI controls
        
        public static bool IsNextPressed()
        {
            return IsKeyPressed(KeyCode.Space);
        }        
        
        public static bool IsUiConfirmPressed()
        {
            return IsKeyHeld(KeyCode.Space) || IsKeyHeld(KeyCode.E);
        }
        
        public static bool IsUiCancelPressed()
        {
            return IsKeyHeld(KeyCode.Escape) || IsKeyHeld(KeyCode.Q);
        }

                
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool IsKeyHeld(KeyCode key)
        {
            return Input.GetKey(key);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool IsKeyPressed(KeyCode key)
        {
            return Input.GetKeyDown(key);
        }
        
}