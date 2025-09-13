using UnityEngine;
using TMPro;

public class Miss_display : MonoBehaviour
{
    public PGM_script pgmScript;
    public TextMeshProUGUI miss_text;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        miss_text.text = "Miss: " + pgmScript.miss_count;
    }
}
