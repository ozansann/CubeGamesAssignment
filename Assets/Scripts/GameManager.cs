using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    Vector3 instantiatePos;
    private int clickNum = 0;     

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hitInfo = new RaycastHit();
            bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);
            instantiatePos = hitInfo.point;
            instantiatePos.y = 1.5f;

            if (hit)
            {
                if(hitInfo.collider.CompareTag("Plane"))
                {
                    clickNum++;
                    if (clickNum % 2 == 1)
                        BallSpawner.instance.SpawnBall(instantiatePos);   
                    else
                        BallSpawner.instance.SetTarget(instantiatePos);
                }
            }
                                                                                        
        }      
    }
}