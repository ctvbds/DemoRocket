using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class main : MonoBehaviour {
    [SerializeField]
    Vector3 vetocity = Vector3.zero;
    [SerializeField]
    float accelemation = 4f;
    [SerializeField]
    float minVelocity;
    [SerializeField]
    float maxVelocity;
    Camera cam;
	// Use this for initialization
	void Start () {
        cam = Camera.main;
	}
	
	// Update is called once per frame
	void Update () {

        //move forward
        if(Input.GetKey(KeyCode.W)){
            vetocity += transform.forward * accelemation;//new Vector2(0, 1 * Time.deltaTime);
        }

        //rotate left
        if(Input.GetKey(KeyCode.A)){
            transform.Rotate(new Vector3(0, -500 * Time.deltaTime));
        }
        //clamp velocity
        vetocity = new Vector3(
            Mathf.Clamp(vetocity.x, minVelocity, maxVelocity),
            Mathf.Clamp(vetocity.x, minVelocity, maxVelocity),
            0);
        transform.position += vetocity;

        //check if we'ar off screen and resolve
        Vector3 screenPos = cam.WorldToViewportPoint(transform.position);
        if(screenPos.y < 0){
            screenPos.y = 1;
        }else if(screenPos.y > 1){
            screenPos.y = 0;
        }
        if (screenPos.x < 0)
        {
            screenPos.x = 1;
        }
        else if (screenPos.x > 1)
        {
            screenPos.x = 0;
        }

        transform.position = cam.ViewportToWorldPoint(screenPos);
        //next

	}

}
