using System.Collections;
using UnityEngine;
using TMPro;

public class PopupManager : MonoBehaviour
{
    public static PopupManager Instance;

    public TextMeshProUGUI popupText;
    private Coroutine currentRoutine;

    public bool isLocked => currentRoutine != null;

    void Awake()
    {
        Instance = this;
        if (popupText != null)
            popupText.gameObject.SetActive(false);
    }

    public void ShowMessages(string[] messages)
    {
        if (currentRoutine != null)
            StopCoroutine(currentRoutine);

        currentRoutine = StartCoroutine(DisplayMessages(messages));
    }

    private IEnumerator DisplayMessages(string[] messages)
    {
        if (popupText == null)
        {
            Debug.LogWarning("Popup text not assigned!");
            yield break;
        }

        popupText.gameObject.SetActive(true);

        foreach (string msg in messages)
        {
            popupText.text = msg;
            yield return new WaitForSecondsRealtime(3f);
        }

        popupText.gameObject.SetActive(false);
        currentRoutine = null;
    }
}