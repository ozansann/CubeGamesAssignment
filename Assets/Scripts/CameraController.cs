using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float speed = 0.01f;  
    public Transform camTransform;
    public Transform pivotTransform;    
    protected Vector3 localRot;
    protected float cameraDist = 10f; 
    public float MouseSensitivity = 40f;
    public float ScrollSensitvity = 2f;
    public float orbitSensitivity = 10f;
    public float scrollSensitivity = 6f;
    public bool pressed = false;

    public void FixedUpdate()
    {                                                                                                  
        if (Input.GetKey(KeyCode.D))
        {
            transform.position = new Vector3(transform.position.x + speed, transform.position.y, transform.position.z);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position = new Vector3(transform.position.x - speed, transform.position.y, transform.position.z);
        }
        if (Input.GetKey(KeyCode.S))
        {                                                                                                                       
            transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y - speed, 15.0f, 500f), transform.position.z);
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y + speed, 15.0f, 500f), transform.position.z);
        }
    }

    void LateUpdate()
    {      
        if (Input.GetMouseButtonDown(2))
        {
            pressed = true;
        }
        if (Input.GetMouseButtonUp(2))
        {
            pressed = false;
        }

        if (((Input.GetAxis("Mouse X") != 0) || (Input.GetAxis("Mouse Y") != 0)) && (pressed))
        {
            localRot.x += Input.GetAxis("Mouse X") * MouseSensitivity;
            localRot.y -= Input.GetAxis("Mouse Y") * MouseSensitivity;
                                                                                
            if (localRot.y < 0f)
                localRot.y = 0f;
            else if (localRot.y > 90f)
                localRot.y = 90f;
        }

        if (Input.GetAxis("Mouse ScrollWheel") != 0f)
        {
            float ScrollAmount = Input.GetAxis("Mouse ScrollWheel") * ScrollSensitvity;  
            ScrollAmount *= (cameraDist * .3f);  
            cameraDist += ScrollAmount * -1f;     
            cameraDist = Mathf.Clamp(cameraDist, 1.5f, 100f);
        }
                                                
        Quaternion QT = Quaternion.Euler(localRot.y, localRot.x, 0);
        transform.rotation = Quaternion.Lerp(transform.rotation, QT, Time.deltaTime * orbitSensitivity);  
    }
}