using UnityEngine;
using UnityEngine.UI;

public class colliede_detect : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Logic_Script lg;
    public Text scoretext;
    private float timer = 1f;
    public float spawntime = 10f;
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

                // ������
                if (target != null)
                {
                    if (target.CompareTag("perfect"))
                    {
                        Debug.Log("Click Perfect!");
                        lg.scoreup(1000);
                        
                            scoretext.text = "Perfect!";
                            
                        
                    }
                    else if (target.CompareTag("good"))
                    {
                        Debug.Log("Click Good!");
                        lg.scoreup(800);
                        
                            scoretext.text = "Good!";
                           
                    }
                    else if (target.CompareTag("bad"))
                    {
                        Debug.Log("Click Bad!");
                        lg.scoreup(200);
                        
                        
                            scoretext.text = "Bad!";
                          
                    }
                }
            }
            else
            {
                Debug.Log("Clicked empty space");
                scoretext.text = "Miss!";
            }
        }
    }


    
}
