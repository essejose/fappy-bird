using UnityEngine;
using System.Collections;

public class MenuController : MonoBehaviour {

    public static MenuController instance;

    [SerializeField]
    private GameObject[] birds;

    private bool isGreenBirdUnlocked, isRedBirdUnlocked, isBlueBirdUnlocked;

    void Awake()
    {
        MakeInstance();
    }
	// Use this for initialization
	void Start () {
        birds[GameController.instance.GetSelectedBird()].SetActive(true);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void MakeInstance()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    void CheckIfBirdAreUnlocked()
    {
        if(GameController.instance.isRedBirdUnlocked() == 1)
        {
            isRedBirdUnlocked = true;
        }

        if (GameController.instance.isGreenBirdUnlocked() == 1)
        {
            isGreenBirdUnlocked = true;
        }

        if (GameController.instance.isBlueBirdUnlocked() == 1)
        {
            isBlueBirdUnlocked = true;
        }
    }

}
