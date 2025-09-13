using UnityEngine;

public class Ending_screen : MonoBehaviour
{
    public bool isEnd = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnEnable()
    {
        isEnd = true;
    }
    void OnDisable()
    {
        isEnd = false;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
