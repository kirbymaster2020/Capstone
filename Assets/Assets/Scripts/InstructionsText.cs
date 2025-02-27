using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class InstructionText : MonoBehaviour
{
    // Supports both regular UI Text and TextMeshPro
    [SerializeField] private Text uiText;
    [SerializeField] private TextMeshProUGUI tmpText;

    [Header("Settings")]
    [SerializeField] private float displayTime = 5f;
    [SerializeField] private float fadeTime = 1f;

    private bool usingTMP = false;

    void Start()
    {
        // Check which text component we're using
        if (uiText == null && tmpText == null)
        {
            // Try to get components if not assigned
            uiText = GetComponent<Text>();
            tmpText = GetComponent<TextMeshProUGUI>();

            if (uiText == null && tmpText == null)
            {
                Debug.LogError("No Text component found on " + gameObject.name + ". Please assign either a UI Text or TextMeshPro Text component.");
                return;
            }
        }

        // Determine which text component to use
        usingTMP = tmpText != null;

        // Make text fully visible to start
        SetTextAlpha(1f);

        // Start showing and hiding text
        StartCoroutine(ShowAndHideText());
    }

    private void SetTextAlpha(float alpha)
    {
        if (usingTMP && tmpText != null)
        {
            Color color = tmpText.color;
            tmpText.color = new Color(color.r, color.g, color.b, alpha);
        }
        else if (!usingTMP && uiText != null)
        {
            Color color = uiText.color;
            uiText.color = new Color(color.r, color.g, color.b, alpha);
        }
    }

    private IEnumerator ShowAndHideText()
    {
        // Display for the specified time minus fade time
        yield return new WaitForSeconds(displayTime - fadeTime);

        // Fade out over time
        float elapsedTime = 0f;

        while (elapsedTime < fadeTime)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeTime);
            SetTextAlpha(alpha);
            yield return null;
        }

        // Ensure text is completely invisible at the end
        SetTextAlpha(0f);

        // Optional: disable the GameObject after fading
        gameObject.SetActive(false);
    }
}