using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float moveSpeed = 10f;

    public float borderWidth = 10f;

    public float scrollSpeed = 10f;
    public float minY = 10f;
    public float maxY = 80f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.mousePosition.x;
        float mouseY = Input.mousePosition.y;

        if (Input.GetKey(KeyCode.W) || (mouseY >= Screen.height-borderWidth && mouseY < Screen.height))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.World);
        }
        if (Input.GetKey(KeyCode.S) || (mouseY > 0 && mouseY <= borderWidth))
        {
            transform.Translate(Vector3.back * Time.deltaTime * moveSpeed, Space.World);
        }
        if (Input.GetKey(KeyCode.A) || (mouseX > 0 && mouseX <= borderWidth))
        {
            transform.Translate(Vector3.left * Time.deltaTime * moveSpeed, Space.World);
        }
        if (Input.GetKey(KeyCode.D) || (mouseX >= Screen.width-borderWidth && mouseX < Screen.width))
        {
            transform.Translate(Vector3.right * Time.deltaTime * moveSpeed, Space.World);
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        Vector3 pos = transform.position;
        pos.y -= scroll * 1000 * scrollSpeed * Time.deltaTime;
        pos.y = Mathf.Clamp(pos.y, minY, maxY);
        transform.position = pos;

        /*
        if (scroll> 0)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * scrollSpeed, Space.Self);
        }
        if (scroll < 0)
        {
            transform.Translate(Vector3.back * Time.deltaTime * scrollSpeed, Space.Self);
        }
        */
    }
}
