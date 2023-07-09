using System.Collections;
using UnityEngine;
using TMPro;

public class BlinkingText : MonoBehaviour
{
    public TextMeshProUGUI blinkingText;
    public float blinkTime = 1f; // The time between each blink

    // Start is called before the first frame update
    void Start()
    {
        // Start a coroutine that makes the text blink
        StartCoroutine(BlinkText());
    }

    IEnumerator BlinkText()
    {
        while (true)
        {
            // Toggle the visibility of the text each frame
            blinkingText.enabled = !blinkingText.enabled;

            // Wait for the specified blink time
            yield return new WaitForSeconds(blinkTime);
        }
    }
}
