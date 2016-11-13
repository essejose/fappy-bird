using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BirdScript : MonoBehaviour {

    public static BirdScript instance;

    [SerializeField]
    private Rigidbody2D myRigiBody;
    [SerializeField]
    private Animator anim;
    
    private float forwardSpeed = 3f;
 
    private float bounceSpeed = 4f;

    private bool didFlap;

    public bool isAlive;

    private Button flapButton;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        isAlive = true;

         //find buttom
        flapButton = GameObject.FindGameObjectWithTag("FlapButton").GetComponent<Button>();
        //implement click
        flapButton.onClick.AddListener(() => FlapTheBird());

        SetCamerasX();
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        if (isAlive)
        {
            Vector2 temp = transform.position;
            temp.x += forwardSpeed * Time.deltaTime;
             transform.position = temp;
            if (didFlap)
            {
                didFlap = false;
                myRigiBody.velocity = new Vector2(0, bounceSpeed);
                anim.SetTrigger("Flap");
            }
        }
        if(myRigiBody.velocity.y >= 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            float angle = 0;
            angle = Mathf.Lerp(0, -90, -myRigiBody.velocity.y /8);
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
	}

    void SetCamerasX()
    {
        CameraScript.offsetX = (Camera.main.transform.position.x - transform.position.x) - 1f;
    }
    public float GetPositionX()
    {
        return transform.position.x;
    }


    public void FlapTheBird()
    {
        didFlap = true;

     

    }
}
