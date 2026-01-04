using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public string hoverText = "Press E";
    public List<GameObject> objectsToToggle;
    public List<GameObject> objectsToDisable;
    public string[] messages;
    public bool blocked = false;
    public bool unblockCondition = false;

    public void Interact()
    {
        if (blocked)
            return;

        foreach (GameObject obj in objectsToToggle)
            if (obj != null)
                obj.SetActive(!obj.activeSelf);

        foreach (GameObject obj in objectsToDisable)
            if (obj != null)
                obj.SetActive(false);

        if (messages != null && messages.Length > 0)
            PopupManager.Instance.ShowMessages(messages);
    }

    void Update()
    {
        if (blocked && unblockCondition)
            blocked = false;
    }
}