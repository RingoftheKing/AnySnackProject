using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;

public class Normal_Note_Script : MonoBehaviour
{
    public int track_no=1;
    public Collider2D perfect_zone;
    public Collider2D good_zone;
    public Collider2D bad_zone;
    public float bottombound = -8.0f;

    [Header("Movement Settings")]
    public float moveSpeed = 5f;
    public bool autoDestroy = true;

    [Header("Track Configuration")]
    public static readonly int TOTAL_TRACKS = 8;
    public static readonly float SCREEN_WIDTH = 19.2f; // 1080p��Ļ���
    public static readonly float TARGET_Y = -9f; // ���й�����յ�Y����

    private Vector3 targetPosition;
    private bool isMoving = false;

    Vector3[] trackPositions = new Vector3[8]
{
    new Vector3(-5f, -9f, 0f),  // ���1
    new Vector3(5f, -9f, 0f),  // ���2
    new Vector3(-1.67f, -9f, 0f),  // ���3
    new Vector3(1.67f, -9f, 0f),  // ���4
    new Vector3(1.2f, -9f, 0f),   // ���5
    new Vector3(3.6f, -9f, 0f),   // ���6
    new Vector3(6.0f, -9f, 0f),   // ���7
    new Vector3(8.4f, -9f, 0f)    // ���8
};

    void Start()
    {
        // ����track_no����Ŀ��λ�ò���ʼ�ƶ�
        SetTargetPosition();
        StartMovement();
    }


    void Update()
    {

        if (isMoving)
        {
            MoveToTarget();
        }
        if (transform.position.y < bottombound)
        {
            Debug.Log("note deleted");
            Destroy(gameObject);
        }
    }

    void StartMovement()
    {
        isMoving = true;
    }

    void SetTargetPosition()
    {        
        targetPosition = GetTrackPosition(track_no);
    }

    public Vector3 GetTrackPosition(int trackNo)
    {
        //if (trackNo > 0 && trackNo <= trackPositions.Length)
        //{
            return trackPositions[trackNo-1];
        //}
        //return Vector3.zero;
    }

    void MoveToTarget()
    {
        // ��Ŀ��λ���ƶ�
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
    }

}