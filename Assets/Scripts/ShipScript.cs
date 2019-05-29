using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipScript : MonoBehaviour
{

    public Camera cam;
    static Rigidbody2D  rigidbody2D;
    static Renderer renderer;
    private float maxWidth;
    private bool canControl;
    
    

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<Renderer>();
        rigidbody2D = GetComponent<Rigidbody2D>();

        if (cam == null)
        {
            cam = Camera.main;
        }

        canControl = false;
        Vector3 upperCorner = new Vector3(Screen.width, Screen.height, 0.0f);
        Vector3 targetWidth = cam.ScreenToWorldPoint(upperCorner);
        float shipWidth =   renderer.bounds.extents.x;
        maxWidth = targetWidth.x - shipWidth;

    }

    // Update is called once per frame
     void FixedUpdate()
    {
        if (canControl) {
        Vector3 rawPosition = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 targetPosition = new Vector3(rawPosition.x, -3.5f, 0.0f);
        float targetWidith = Mathf.Clamp(targetPosition.x, -maxWidth, maxWidth);
        targetPosition = new Vector3(targetWidith, targetPosition.y, targetPosition.z);
        rigidbody2D.MovePosition(targetPosition);
        }
    }    

    public void ToggleControl(bool toggle)
    {
        canControl = toggle;
    }
}

