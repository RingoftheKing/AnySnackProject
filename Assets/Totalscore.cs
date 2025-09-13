using UnityEngine;
using TMPro;

public class Totalscore : MonoBehaviour
{
    public PGM_script pgmScript;
    public TextMeshProUGUI total_score_text;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        total_score_text.text = "Total Score: " + pgmScript.total_score;
    }
}
