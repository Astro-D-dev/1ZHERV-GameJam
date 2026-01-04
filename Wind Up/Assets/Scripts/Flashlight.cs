using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Flashlight : MonoBehaviour
{
    public Light2D flashlight;
    [Range(0f,1f)] public float charge = 1f;
    public bool flashlightOn = false;

    void Update()
    {
        if (flashlightOn)
        {
            Vector3 mouseWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouseWorld.z = 0f;
            transform.position = mouseWorld;
            flashlight.intensity = charge;
        }
        else
        {
            flashlight.intensity = 0f;
        }
    }

    public void ToggleFlashlight()
    {
        flashlightOn = !flashlightOn;
    }
}
