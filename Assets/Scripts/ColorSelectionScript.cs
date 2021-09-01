using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorSelectionScript : MonoBehaviour
{
    public Material orange, yellow, blue, purple;
    public GameObject plane;     

    public void setBallColorToOrange()
    {
        BallSpawner.instance.instantiateMaterial = orange;        
    }

    public void setBallColorToYellow()
    {
        BallSpawner.instance.instantiateMaterial = yellow;
    }

    public void setBallColorToBlue()
    {
        BallSpawner.instance.instantiateMaterial = blue;
    }

    public void setBallColorToPurple()
    {
        BallSpawner.instance.instantiateMaterial = purple;
    }

    public void setPlaneColorToOrange()
    {
        plane.GetComponent<MeshRenderer>().material = orange;
    }

    public void setPlaneColorToYellow()
    {
        plane.GetComponent<MeshRenderer>().material = yellow;
    }

    public void setPlaneColorToBlue()
    {
        plane.GetComponent<MeshRenderer>().material = blue;
    }

    public void setPlaneColorToPurple()
    {
        plane.GetComponent<MeshRenderer>().material = purple;
    }
}
