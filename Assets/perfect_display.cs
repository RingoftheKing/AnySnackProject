using UnityEngine;
using TMPro;
public class Perfect_display : MonoBehaviour
{
    public PGM_script pgmScript;
    public TextMeshProUGUI perfect_text;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        perfect_text.text = "Perfect: " + pgmScript.perfect_count;
    }
}
