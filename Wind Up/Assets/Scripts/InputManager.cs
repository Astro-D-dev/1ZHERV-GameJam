using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance;
    private bool flashlightSwitched = false;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
        }

        if (Input.GetKeyDown(KeyCode.E))
            Interact();
        
        if (Input.GetKeyDown(KeyCode.F))
            Flashlight();
        
        if (Input.GetMouseButtonDown(0))
            WindUp();
    }

    void Interact()
    {
        Debug.Log("Interacted");
    }

    void Flashlight()
    {
        Debug.Log("Flashlight Switched");
        flashlightSwitched = !flashlightSwitched;
    }

    void WindUp()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        if (h != 0 || v != 0)
            Debug.Log($"Moving: {h}, {v}");
    }
}
