using UnityEngine;
using System.Collections;

public class PipeCollector : MonoBehaviour {

    private GameObject[] pipeHolder;
    private float distance = 2.5f;
    private float lastPipeX;
    private float pipeMin = -1.5f;
    private float pipeMax = 2.4f;


	// Use this for initialization
	void Awake () {
        pipeHolder = GameObject.FindGameObjectsWithTag("PipeHolder");

        for (int i = 0; i < pipeHolder.Length; i++)
        {
            Vector3 temp = pipeHolder[i].transform.position;
            temp.y = Random.Range(-3,0);
            pipeHolder[i].transform.position = temp;


        }

        lastPipeX = pipeHolder[0].transform.position.x;

        for (int i = 0; i < pipeHolder.Length; i++)
        {
            if(lastPipeX < pipeHolder[i].transform.position.x)
            {
                
                lastPipeX = pipeHolder[i].transform.position.x;
                
            }

        }

    }

  
    void OnTriggerEnter2D(Collider2D target) {

        Debug.Log(target.tag); 
	    if(target.tag == "PipeHolder")
        {
            Vector3 temp = target.transform.position;
            temp.x = lastPipeX + distance;
            temp.y = Random.Range(pipeMin, pipeMax);

            target.transform.position = temp;
            lastPipeX = temp.x;
        }
	}
}
