using UnityEngine;
using UnityEngine.Rendering;

public class MouseManager : MonoBehaviour
{
    private Vector3 MousePosition;
    // public Camera cam;
    
    public float ring_radius;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    Vector3 point = new Vector3();
    Vector2 mousePosition = new Vector2();
    
    void Start()
    {
        //
        // cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        mousePosition = Input.mousePosition;
        point = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, Camera.main.nearClipPlane));
        this.transform.position = point;
        float normalized = ring_radius / Mathf.Sqrt(point.x * point.x + point.y * point.y);
        transform.position = new Vector3(normalized * point.x, normalized * point.y, -1);
    }
}
