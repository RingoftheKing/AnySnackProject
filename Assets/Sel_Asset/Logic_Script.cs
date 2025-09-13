using UnityEngine;
using UnityEngine.UI;

public class Logic_Script : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int score=0;
    public Text scoretext;
    //public GameObject gameovermenu;

    [ContextMenu("scoreup")]
    public void scoreup(int scoretoadd)
    {
        score += scoretoadd;
        Debug.Log("Score increased by " + scoretoadd + ", total score: " + score);
        scoretext.text ="Score:" + score.ToString();
    }
}
