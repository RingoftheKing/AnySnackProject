using UnityEngine;
using TMPro;
using System.Collections;

public class TypewriterEffect3 : MonoBehaviour
{
    public TextMeshProUGUI textMesh;
    public string fullText;
    public float delay = 0.05f;
    public PGM_script pgmScript;
    public Ending_screen endingScreen;

    void Update()
    {
        if (endingScreen.isEnd == true)
        { StartCoroutine(ShowText()); }
    }

    IEnumerator ShowText()
    {
        textMesh.text = "Good: " + pgmScript.good_count;
        foreach (char c in fullText)
        {
            textMesh.text += c;
            yield return new WaitForSeconds(delay);
        }
    }
}
