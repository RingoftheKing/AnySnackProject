using UnityEngine;

public class colliede_detect : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Êó±ê×ó¼ü°´ÏÂ
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D hit = Physics2D.OverlapPoint(mousePos);

            if (hit != null)
            {
                if (hit.CompareTag("perfect"))
                {
                    Debug.Log("Click Perfect!");
                }
                else if (hit.CompareTag("good"))
                {
                    Debug.Log("Click Good!");
                }
                else if (hit.CompareTag("bad"))
                {
                    Debug.Log("Click Bad!");
                }
                else
                {
                    Debug.Log("Clicked on collider but tag not detected");
                }
            }
            else
            {
                Debug.Log("Clicked empty space");
            }
        }

    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.CompareTag("perfect"))
    //    {

    //        Debug.Log("Perfect!");
    //    }
    //    else if (collision.gameObject.CompareTag("good"))
    //    {
    //        Debug.Log("Good!");
    //    }
    //    else if (collision.gameObject.CompareTag("bad"))
    //    {
    //        Debug.Log("Bad!");
    //    }
    //    else
    //    {
    //        Debug.Log("Collide cannot detect");
    //    }
    //}
}
