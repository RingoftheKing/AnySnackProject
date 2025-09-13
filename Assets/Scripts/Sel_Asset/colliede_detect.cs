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
        if (Input.GetMouseButtonDown(0)) // ����������
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // ��ȡ�����������ײ��
            Collider2D[] hits = Physics2D.OverlapPointAll(mousePos);

            if (hits.Length > 0)
            {
                Collider2D target = null;

                // �����ȼ�ѡ��
                foreach (Collider2D hit in hits)
                {
                    if (hit.CompareTag("perfect"))
                    {
                        target = hit;
                        break; // ���� perfect
                    }
                }

                // ���û�� perfect������ good
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

                // ���û�� perfect �� good������ bad
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

                // �������
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
                    Destroy(gameObject);
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
