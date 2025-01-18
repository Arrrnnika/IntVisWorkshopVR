using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProximityTrigger : MonoBehaviour
{
    public Transform playerPos; //Field will be visible in the Inspector -> Drag the Camera Object of the hierarchy to this field
    private Renderer cubeRen;   //The Renderer tells Unity how to "draw" the object on the scene (Makes object visible) and controls things like material, color,...
    private Color defaultColor;
    private Color closeColor = Color.red;
    
    // Start is called before the first frame update
    void Start()
    { 
        cubeRen = GetComponent<Renderer>();             //We get the Cube's Renderer
        if (cubeRen != null)                            //If it exists...
        {
            defaultColor = cubeRen.material.color;      //We take the color the cube usually has (=white in this example)
        }
    }

    // Update is called once per frame, so that every frame if a change has happened, we can update the scene
    void Update()
    {
        float distanceToPlayer = Vector3.Distance(playerPos.position, transform.position);  //transform.position is where the cube is at, playerPos is of type
        //Transform as well (see line 8) -> Get player position & calculate distance between player and cube
        
        if (distanceToPlayer <= 1.5f)               //check if we are below a certain threshold (can be larger/smaller, doesn't have to be 1.5f)
        {
            cubeRen.material.color = closeColor;    //if we are that close, we change the Color to red!
        }
        else
        {
            cubeRen.material.color = defaultColor;  //If we are farther, we change the color back to the default one!
        }
        
    }
}
