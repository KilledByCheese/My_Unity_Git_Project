using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
*	Author: Marcel
*	Version: 1.0
*	Date: 02.05.2018
*	Reference: https://www.youtube.com/watch?v=MFQhpwc6cKE 
*/

public class SmoothCameraFollow : MonoBehaviour {

    public Transform target;
    public float smoothSpeed; //higher Value = faster lock on
    public Vector3 offset;
    public Vector3 desiredPosition;
    public Vector3 smoothedPosition;
    private Vector3 velocity;

    // Use this for initialization
    public void Start () {
		smoothSpeed = 5f;
        velocity = Vector3.zero;
        offset = new Vector3(0, 2, -10);
        setDesiredPosition();
        setSmoothedPosition();           
     }
	
	// Update is called once per frame
	public void Update () {
		
	}

    //running after Update() 
    private void LateUpdate() //Maybe replace with FixedUpdate
    {
        setDesiredPosition();
        setSmoothedPosition();
        transform.position = smoothedPosition;
        transform.LookAt(target);
    }

    private void setDesiredPosition()
    {
        desiredPosition = target.position + offset;
    }

    private void setSmoothedPosition()
    {
        smoothedPosition = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, (smoothSpeed * Time.deltaTime));     
    }
}
