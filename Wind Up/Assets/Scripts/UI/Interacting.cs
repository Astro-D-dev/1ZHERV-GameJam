using UnityEngine;
using TMPro;

public class Interacting : MonoBehaviour
{
    public TextMeshProUGUI popupText;
    private Interactable currentHover;

    void Update()
    {
        DetectHover();
    }

    void DetectHover()
    {
        Vector2 mouseWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Collider2D hit = Physics2D.OverlapPoint(mouseWorld);

        if (hit == null)
        {
            ClearHover();
            return;
        }

        Interactable interactable = hit.GetComponent<Interactable>();
        if (interactable == null)
        {
            ClearHover();
            return;
        }

        currentHover = interactable;
        popupText.text = interactable.hoverText;
        popupText.gameObject.SetActive(true);
    }

    void ClearHover()
    {
        currentHover = null;

        if (PopupManager.Instance == null || !PopupManager.Instance.isLocked)
            popupText.gameObject.SetActive(false);
    }
    
    public void TryInteract()
    {
        if (currentHover != null)
            currentHover.Interact();
    }
}
