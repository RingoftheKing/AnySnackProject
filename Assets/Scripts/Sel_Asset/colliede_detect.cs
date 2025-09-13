using UnityEngine;

public class colliede_detect : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Logic_Script lg;
    void Start()
    {
        lg = GameObject.FindGameObjectWithTag("logic").GetComponent<Logic_Script>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // 鼠标左键按下
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // 获取鼠标下所有碰撞器
            Collider2D[] hits = Physics2D.OverlapPointAll(mousePos);

            if (hits.Length > 0)
            {
                Collider2D target = null;

                // 按优先级选择
                foreach (Collider2D hit in hits)
                {
                    if (hit.CompareTag("perfect"))
                    {
                        target = hit;
                        break; // 优先 perfect
                    }
                }

                // 如果没有 perfect，再找 good
                if (target == null)
                {
                    foreach (Collider2D hit in hits)
                    {
                        if (hit.CompareTag("good"))
                        {
                            target = hit;
                            break;
                        }
                    }
                }

                // 如果没有 perfect 或 good，再找 bad
                if (target == null)
                {
                    foreach (Collider2D hit in hits)
                    {
                        if (hit.CompareTag("bad"))
                        {
                            target = hit;
                            break;
                        }
                    }
                }

                // 处理点击
                if (target != null)
                {
                    if (target.CompareTag("perfect"))
                    {
                        Debug.Log("Click Perfect!");
                        lg.scoreup(1000);
                    }
                    else if (target.CompareTag("good"))
                    {
                        Debug.Log("Click Good!");
                        lg.scoreup(800);
                    }
                    else if (target.CompareTag("bad"))
                    {
                        Debug.Log("Click Bad!");
                        lg.scoreup(200);
                    }
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
