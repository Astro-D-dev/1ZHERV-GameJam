using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Flashlight : MonoBehaviour
{
    public Light2D flashlight;
    [Range(0f,1f)] public float charge = 0f;
    public bool flashlightOn = false;

    public float chargeRate = 0.2f;
    public float decayRate = 0.1f;
    private Vector3 lastMousePos;
    private bool firstFrame = true;

    void Update()
    {
        HandleMouseInput();
        DecayCharge();
        UpdateFlashlight();
    }

    void HandleMouseInput()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 mouseScreen = Input.mousePosition;

            if (!firstFrame)
            {
                float dist = Vector3.Distance(mouseScreen, lastMousePos);
                charge += dist * chargeRate * Time.deltaTime;
            }

            lastMousePos = mouseScreen;
            firstFrame = false;
        }
        else
        {
            firstFrame = true;
        }
    }

    void DecayCharge()
    {
        charge -= decayRate * Time.deltaTime;
        charge = Mathf.Clamp01(charge);
    }

    void UpdateFlashlight()
    {
        if (flashlightOn && flashlight != null)
        {
            Vector3 mouseWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouseWorld.z = 0f;
            transform.position = mouseWorld;
            flashlight.intensity = charge;
        }
        else if (flashlight != null)
        {
            flashlight.intensity = 0f;
        }
    }

    public void ToggleFlashlight()
    {
        flashlightOn = !flashlightOn;
    }
}
