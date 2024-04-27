using UnityEngine;

public class CursorManager : MonoBehaviour
{
    // You can set this flag in the Unity Editor to control cursor visibility
    public bool showCursor = true;

    void Start()
    {
        // Set the cursor visibility and lock state
        Cursor.visible = showCursor;
        Cursor.lockState = showCursor ? CursorLockMode.None : CursorLockMode.Locked;
    }

    // You can call this method to toggle cursor visibility during runtime
    public void ToggleCursorVisibility()
    {
        showCursor = !showCursor;
        Cursor.visible = showCursor;
        Cursor.lockState = showCursor ? CursorLockMode.None : CursorLockMode.Locked;
    }
}
