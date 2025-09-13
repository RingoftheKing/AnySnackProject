using UnityEngine;
using TMPro;
using System.Collections;

public class ConditionalFadeText : MonoBehaviour
{
    public TextMeshProUGUI textMesh;
    public float fadeDuration = 1f;
    public float displayTime = 2f;
    public PGM_script pgmScript;
    // Call this when the condition is met
    public void ShowText(string message, Color color)
    {
        textMesh.text = message;
        textMesh.color = color;
        StopAllCoroutines(); // In case it was already running
        StartCoroutine(FadeInAndOut());
    }

    IEnumerator FadeInAndOut()
    {
        // Fade in
        Color color = textMesh.color;
        color.a = 0;
        textMesh.color = color;

        float t = 0;
        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            color.a = Mathf.Lerp(0, 1, t / fadeDuration);
            textMesh.color = color;
            yield return null;
        }

        // Wait
        yield return new WaitForSeconds(displayTime);

        // Fade out
        t = 0;
        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            color.a = Mathf.Lerp(1, 0, t / fadeDuration);
            textMesh.color = color;
            yield return null;
        }
    }
    void Update()
    {
        if (pgmScript.isPerfect == true) // condition
        {
            GetComponent<ConditionalFadeText>().ShowText("Perfect!!",Color.blue);
        }
        if (pgmScript.isGood == true) // condition
        {
            GetComponent<ConditionalFadeText>().ShowText("Good!", Color.green);
        }
        if (pgmScript.isMiss == true) // condition
        {
            GetComponent<ConditionalFadeText>().ShowText("Miss...", Color.red);
        }
    }

}
