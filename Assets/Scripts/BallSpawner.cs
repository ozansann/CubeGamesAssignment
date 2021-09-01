using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    public static BallSpawner instance;
    public GameObject ball;
    private GameObject ballClone;
    public Material instantiateMaterial;

    void Awake()
    {
        instance = this;
    }

    public void SpawnBall(Vector3 position)
    {
        ballClone = Instantiate(ball, position, ball.transform.rotation) as GameObject;  
        ballClone.GetComponent<MeshRenderer>().material = instantiateMaterial;
    }

    public void SetTarget(Vector3 position)
    {
        Ball ball = ballClone.GetComponent<Ball>();
        ball.target = position;
        ball.StartProjectile();
    }
}
