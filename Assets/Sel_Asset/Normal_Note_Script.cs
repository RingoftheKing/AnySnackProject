using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;

public class Normal_Note_Script : MonoBehaviour
{
    public int track_no=1;
    public Collider2D perfect_zone;
    public Collider2D good_zone;
    public Collider2D bad_zone;
    public float bottombound = -7.0f;
    public float topbound = 8.0f;
    public float leftbound = -11.0f;
    public float rightbound = 11.0f;


    [Header("Movement Settings")]
    public float moveSpeed = 5f;
    public bool autoDestroy = true;

    [Header("Track Configuration")]
    public static readonly int TOTAL_TRACKS = 8;
    public static readonly float SCREEN_WIDTH = 19.2f; // 1080p屏幕宽度
    public static readonly float TARGET_Y = -9f; // 所有轨道的终点Y坐标

    private Vector3 targetPosition;
    private bool isMoving = false;

    Vector3[] trackPositions = new Vector3[12]
{
    new Vector3(3.37f, 12.68f, 0f),  // 轨道1
    new Vector3(9.24f,9.3f, 0f),  // 轨道2
    new Vector3(12.64f, 3.41f, 0f),  // 轨道3
    new Vector3(12.52f, -3.32f, 0f),  // 轨道4
    new Vector3(9.21f, -9.34f, 0f),   // 轨道5
    new Vector3(3.49f, -12.65f, 0f),   // 轨道6
    new Vector3(-3.49f, -12.65f, 0f),   // 轨道7
    new Vector3(-9.21f, -9.34f, 0f),
    new Vector3(-12.52f, -3.32f, 0f),
    new Vector3(-12.64f, 3.41f, 0f),
    new Vector3(-9.24f,9.3f, 0f),
    new Vector3(-3.37f, 12.68f, 0f)
};

    void Start()
    {
        // 根据track_no设置目标位置并开始移动
        SetTargetPosition();
        StartMovement();
    }


    void Update()
    {

        if (isMoving)
        {
            MoveToTarget();
        }
        if (transform.position.y < bottombound || transform.position.x<leftbound || transform.position.x > rightbound || transform.position.y>topbound)
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
        // 向目标位置移动
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
    }

}