using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    [Header("Hover")]
    public string hoverText = "Press E";

    [Header("Objects to Toggle")]
    public List<GameObject> objectsToToggle;
    public bool toggleSelf = false; 

    [Header("Messages")]
    public string[] messages;

    public void Interact()
    {
        foreach (GameObject obj in objectsToToggle)
        {
            if (obj != null)
                obj.SetActive(!obj.activeSelf);
        }

        if (toggleSelf)
            gameObject.SetActive(!gameObject.activeSelf);

        if (messages != null && messages.Length > 0)
            PopupManager.Instance.ShowMessages(messages);
    }
}