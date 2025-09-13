using UnityEngine;

public class PGM_script : MonoBehaviour
{
    public int perfect_count = 0;
    public int good_count = 0;
    public int miss_count = 0;
    public int total_score = 0;
    public bool isPerfect = false;
    public bool isGood = false;
    public bool isMiss = false;
    public GameObject panelToClose;
    public GameObject panelToOpen;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            isPerfect = true;
        }
        else { isPerfect = false; }
        if (Input.GetKeyDown(KeyCode.S))
        {
            isGood = true;
        }
        else { isGood = false; }
        if (Input.GetKeyDown(KeyCode.X))
        {
            isMiss = true;
        }
        else { isMiss = false; }
        if (isPerfect == true)
        {
            perfect_count += 1;
        }
        if (isGood == true)
        {
            good_count += 1;
        }
        if (isMiss == true)
        {
            miss_count += 1;
        }
        total_score = (perfect_count * 10) + (good_count * 8) + (miss_count * 0);
        if (miss_count >= 10)
        {
            Debug.Log("Game Over");
            panelToClose.SetActive(false);
            panelToOpen.SetActive(true);
        }
    }
}
