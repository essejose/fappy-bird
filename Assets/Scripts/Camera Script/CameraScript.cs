using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

    public static float offsetX;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (BirdScript.instance.isAlive)
        {
            MoveTheCamera();
        }
	}


    void SetCamerasX()
    {
        CameraScript.offsetX = (Camera.main.transform.position.x - transform.position.x) - 2f;
    }
    void MoveTheCamera()
    {
        Vector3 temp = transform.position;
        temp.x = BirdScript.instance.GetPositionX() + offsetX;
        transform.position = temp;
    }
}
