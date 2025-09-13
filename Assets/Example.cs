using UnityEngine;

public class Example : MonoBehaviour
{
    public int score = 0;

    void Update()
    {
        // Example condition: if player presses space
        if (Input.GetKeyDown(KeyCode.Space))
        {
            score += 10;  // Increase score by 10
            Debug.Log("Score is now: " + score);
        }

        // Another condition: if score exceeds 50
        if (score > 50)
        {
            score = 50;  // Cap the score at 50
        }
    }
}
