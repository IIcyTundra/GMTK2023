using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SceneFade : MonoBehaviour
{
    public Image fadeOverlay;
    public float fadeSpeed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        // Start a coroutine to fade in the scene
        StartCoroutine(FadeIn());
    }

    IEnumerator FadeIn()
    {
        float t = 1f;

        while (t > 0f)
        {
            t -= Time.deltaTime * fadeSpeed;

            // Update the color of the fade overlay
            Color color = fadeOverlay.color;
            color.a = Mathf.Lerp(0f, 1f, t);
            fadeOverlay.color = color;

            yield return null;
            fadeOverlay.gameObject.SetActive(false);
        }
    }
}
