using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Vector3 target;
    public float firingAngle = 45.0f;
    public float gravity = 9.8f, maxHeight=0, hmax, currentSpeedValue;         
    public Transform Projectile;
    private Transform myTransform;

    void Awake()
    {
        myTransform = transform;
    }

    public void StartProjectile()
    {
        StartCoroutine(SimulateProjectile());
    }
           
    IEnumerator SimulateProjectile()
    {                                                     
        yield return new WaitForSeconds(0f);                                                
        Projectile.position = myTransform.position + new Vector3(0, 0.0f, 0); 
        float target_Distance = Vector3.Distance(Projectile.position, target);  
        hmax = MaxHeightValueScript.instance.currentMaxHeightValue;   
        firingAngle = Mathf.Atan(4.0f * hmax / target_Distance) * Mathf.Rad2Deg;    
        currentSpeedValue = SpeedValueScript.instance.currentSpeedValue;                
        float projectile_Velocity = target_Distance / (Mathf.Sin(2 * firingAngle * Mathf.Deg2Rad) / gravity);  
        float Vx = Mathf.Sqrt(projectile_Velocity) * Mathf.Cos(firingAngle * Mathf.Deg2Rad);
        float Vy = Mathf.Sqrt(projectile_Velocity) * Mathf.Sin(firingAngle * Mathf.Deg2Rad);  
        float flightDuration = target_Distance / Vx / currentSpeedValue;         
        Projectile.rotation = Quaternion.LookRotation(target - Projectile.position);   
        float elapse_time = 0;

        while (elapse_time < flightDuration)
        {
            Projectile.Translate(0, (Vy / currentSpeedValue - (gravity * elapse_time)) * Time.deltaTime * currentSpeedValue * currentSpeedValue, Vx * Time.deltaTime* currentSpeedValue);
            elapse_time += Time.deltaTime; 
            if(transform.position.y > maxHeight)
            {
                maxHeight = transform.position.y;
            }                
            yield return null;
        }                             
    }
}