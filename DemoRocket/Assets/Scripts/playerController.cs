using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class playerController : MonoBehaviour {
    public Text textX;
    public Text textY;
    public Text textZ;
    public Button runBtn;
    public InputField tf_X;
    public InputField tf_Y;
    public InputField tf_Z;
    public bool isClick;

    [SerializeField]
    Vector3 vetocity = Vector3.zero;
    [SerializeField]
    float accelemation = 4f;
    [SerializeField]
    float minVelocity;
    [SerializeField]
    float maxVelocity = 100;
    Camera cam;
    // Use this for initialization
    void Start()
    {
        cam = Camera.main;
        //Button btn1 = runBtn.GetComponent<Button>();
        //runBtn.onClick.AddListener(TaskOnClick);


    }
   
    //private void Awake()
    //{
    //       textX = GetComponent<Text>();
    //       textY = GetComponent<Text>();
    //       textZ = GetComponent<Text>();

    //}
    // Update is called once per frame
    void Update()
    {
        if (isClick == true)
        {
            print("vo");
            //move forward
            if (Input.GetKey(KeyCode.W))
            {
                vetocity -= transform.forward * accelemation * Time.deltaTime;//new Vector2(0, 1 * Time.deltaTime);
            }

            //rotate left
            if (Input.GetKey(KeyCode.A))
            {
                transform.Rotate(new Vector3(0, 5 * accelemation * Time.deltaTime, 0));
            }
            //rotate right
            if (Input.GetKey(KeyCode.X))
            {
                transform.Rotate(new Vector3(0, -5 * accelemation * Time.deltaTime, 0));
            }


            //clamp velocity
            vetocity = new Vector3(
            Mathf.Clamp(vetocity.x, minVelocity, maxVelocity),
            Mathf.Clamp(-vetocity.x, minVelocity, maxVelocity),
            0);
            //vetocity = Vector3.ClampMagnitude(vetocity, maxVelocity);
            print(vetocity.x);
            print(vetocity.y);
            print(vetocity.z);

            transform.position -= (vetocity * -0.75f);
       
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
        }
        else
        {
            //move forward
            if (Input.GetKey(KeyCode.W))
            {
                vetocity += transform.forward * accelemation * Time.deltaTime;//new Vector2(0, 1 * Time.deltaTime);
            }

            //rotate left
            if (Input.GetKey(KeyCode.A))
            {
                transform.Rotate(new Vector3(0, -5 * accelemation * Time.deltaTime, 0));
            }
            //rotate right
            if (Input.GetKey(KeyCode.D))
            {
                transform.Rotate(new Vector3(0, 5 * 0.75f, 0));
            }


            //clamp velocity
            vetocity = new Vector3(
            Mathf.Clamp(vetocity.x, minVelocity, maxVelocity),
            Mathf.Clamp(vetocity.x, minVelocity, maxVelocity),
            0);
            //vetocity = Vector3.ClampMagnitude(vetocity, maxVelocity);
            //print(vetocity.x);

            transform.position += (vetocity * accelemation * Time.deltaTime);

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
        }
            //print(transform.position);
        textX.text = "" + transform.position.x;
        textY.text = "" + transform.position.y;
        textZ.text = "" + transform.position.z;
        //next
    }

    public void TaskOnClick()
    {
        isClick = true;
        //Output this to console when the Button is clicked
        Debug.Log("You have clicked the button!");
  
        tf_X.text = "" + transform.position.x;
        tf_Y.text = "" + transform.position.y;
        tf_Z.text = "" + transform.position.z;
    }


}

   
