using UnityEngine;
using System.Collections;

public class BGCollector : MonoBehaviour {

    private GameObject[] backgrounds;

    private GameObject[] grounds;

    private float lastBGX;
    private float lastGroundX;


    void Awake()
    {

        backgrounds = GameObject.FindGameObjectsWithTag("Background");
        grounds = GameObject.FindGameObjectsWithTag("Ground");

        lastBGX = backgrounds[0].transform.position.x;
        lastGroundX = grounds[0].transform.position.x;

        //
        for (int i = 0; i < backgrounds.Length; i++)
        {
            if (lastBGX < backgrounds[i].transform.position.x)
            {
                lastBGX = backgrounds[i].transform.position.x;
            }
        }

        for (int i = 0; i < grounds.Length; i++)
        {
            if (lastGroundX < grounds[i].transform.position.x)
            {
                lastGroundX = grounds[i].transform.position.x;
            }
        }
    }

       
       void OnTriggerEnter2D(Collider2D target){
        Debug.Log(lastBGX);
        Debug.Log(target.tag);
            if (target.tag == "Background")
            {
                Vector3 temp = target.transform.position;
                float width = ((BoxCollider2D)target).size.x;

                temp.x = lastBGX + width;
                target.transform.position = temp;
                lastBGX = temp.x;
            }
                else if (target.tag == "Ground")
                {
                    Vector3 temp = target.transform.position;
                    float width = ((BoxCollider2D)target).size.x;

                    temp.x = lastGroundX + width;
                    target.transform.position = temp;
                    lastGroundX = temp.x;
        }

    }

    // Update is called once per frame
    void Update () {
    
    }
}
