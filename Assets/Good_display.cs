using UnityEngine;
using TMPro;

public class Good_display : MonoBehaviour
{
    public PGM_script pgmScript;
    public TextMeshProUGUI good_text;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        good_text.text = "Good: " + pgmScript.good_count;
    }
}
