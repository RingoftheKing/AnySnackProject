using System;
using UnityEngine;

public class HoldNote : MonoBehaviour
{
    [Header("Normal Note Prefab Goes here")]
    public GameObject note; // This is used for hitbox for the initial touch
    public GameObject judgementLine;
    
    [Header("Stretchable asset (the body of the hold note)")]
    public GameObject bodyPrefab;
    
    public float noteSpeed;
    public Vector3 startPosition; 
    public Transform target;
    
    private bool _finishedSpawning = false;
    private GameObject _bodyInstance;
    private Transform _bodyTransform;
    
    public float holdDuration = 2f;
    private float _currentHoldTime = 0f;

    public void Init(Vector3 startPos, Transform targetTransform)
    {
        this.startPosition = startPos;
        transform.position = startPos;
        
        this.startPosition = startPos;
        this.target = targetTransform;
        transform.position = startPos;
        
        Vector3 dir = (target.position - startPosition).normalized;
        if (dir != Vector3.zero)
            transform.rotation = Quaternion.LookRotation(Vector3.forward, dir);

        // Spawn stretchable body
        _bodyInstance = Instantiate(bodyPrefab, transform);
        _bodyTransform = _bodyInstance.transform;

        // Place it behind the head
        _bodyTransform.localPosition = Vector3.zero;
        _bodyTransform.localScale = new Vector3(10f, 10f, 1f); // start tiny
    }
    
    void Start()
    {
        // transform.position = startPosition;
        // Vector3 dir = (target.position - startPosition).normalized;
        // if (dir != Vector3.zero)
        //     transform.rotation = Quaternion.LookRotation(Vector3.forward, dir);
        
        if (_bodyInstance == null)
        {
            _bodyInstance = Instantiate(bodyPrefab, transform);
        }

        if (_bodyTransform == null)
        {
            _bodyTransform = _bodyInstance.transform;
            _bodyTransform.localPosition = Vector3.zero;
            _bodyTransform.localScale = new Vector3(1f, 1f, 1f);
        }
    }

    public void setDone()
    {
        _finishedSpawning = true;
    }

    void elongate()
    {
        // Stretch the provided asset
        if (_bodyTransform == null) return;

        // Grow length of the body over time
        _currentHoldTime += Time.deltaTime;
        float progress = Mathf.Clamp01(_currentHoldTime / holdDuration);

        // Scale on Y (or Z depending on your sprite orientation)
        _bodyTransform.localScale = new Vector3(
            _bodyTransform.localScale.x,
            Mathf.Lerp(0.01f, 1f, progress), // grows taller
            _bodyTransform.localScale.z
        );

        // Optional: push body backward so it "extends" behind the head
        _bodyTransform.localPosition = new Vector3(0f, -_bodyTransform.localScale.y / 2f, 0f);
    }
    
    private float internalTime = 0f;
    void shrink()
    {
        if (_bodyTransform == null) return;

        internalTime += Time.deltaTime;
        float progress = Mathf.Clamp01(internalTime / holdDuration);
        // Shrink over time until destroyed
        _bodyTransform.localScale = new Vector3(
            _bodyTransform.localScale.x,
            Mathf.Lerp(1f, 0.01f, progress), // grows shorter
            _bodyTransform.localScale.z
        );

        if (_bodyTransform.localScale.magnitude < 0.01f)
        {
            Destroy(gameObject); // Remove note entirely
        }
    }
    
    void Update()
    {
        if (target != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, Time.deltaTime * noteSpeed);
        }

        if (!_finishedSpawning)
        {
            elongate();
        }

        // should not be strict but also allows some tolerance
        if (Vector3.Distance(transform.position, target.position) < 0.05f)
        {
            shrink();
        }
        
    }
}
