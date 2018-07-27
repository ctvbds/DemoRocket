using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class playerController : MonoBehaviour {
    [SerializeField]
    Vector3 vetocity = Vector3.zero;
    [SerializeField]
    float accelemation = 4f;
    //[SerializeField]
    //float minVelocity;
    [SerializeField]
    float maxVelocity = 100;
    Camera cam;
    // Use this for initialization
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {

        //move forward
        if (Input.GetKey(KeyCode.W))
        {
            vetocity += transform.forward * accelemation *Time.deltaTime;//new Vector2(0, 1 * Time.deltaTime);
        }

        //rotate left
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(new Vector3(0, -50 * Time.deltaTime, 50));
        }
        //rotate right
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(new Vector3(0, 50 * Time.deltaTime, 60));
        }
        //clamp velocity
        //vetocity = new Vector3(
        //Mathf.Clamp(vetocity.x, minVelocity, maxVelocity),
        //Mathf.Clamp(vetocity.x, minVelocity, maxVelocity),
        //0);
        vetocity = Vector3.ClampMagnitude(vetocity, maxVelocity);
        transform.position += (vetocity * 0.75f); 

        //check if we'ar off screen and resolve
        //Vector3 screenPos = cam.WorldToViewportPoint(transform.position);
        Vector3 screenPos = cam.WorldToViewportPoint(transform.position);
        // set y
        if (screenPos.y < 0)
        {
            screenPos.y = 1;
        }
        else if (screenPos.y > 1)
        {
            screenPos.y = 0;
        }
        //set x
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
