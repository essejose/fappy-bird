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
        CheckIfBirdAreUnlocked();
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


    public void ChangeBird()
    {

        Debug.Log(GameController.instance.GetSelectedBird());
        if(GameController.instance.GetSelectedBird () == 0)
        {
            if (isGreenBirdUnlocked)
            {
                birds[0].SetActive(false);
                GameController.instance.SetSelectdBird(1);
                birds[GameController.instance.GetSelectedBird()].SetActive(true);


            }
        }else if(GameController.instance.GetSelectedBird() == 1)
        {
            if (isRedBirdUnlocked)
            {
                birds[1].SetActive(false);
                GameController.instance.SetSelectdBird(2);
                birds[GameController.instance.GetSelectedBird()].SetActive(true);

            }
            else
            {
                birds[1].SetActive(false);
                GameController.instance.SetSelectdBird(0);
                birds[GameController.instance.GetSelectedBird()].SetActive(true);
            }
        }else if(GameController.instance.GetSelectedBird() == 2)
        {
            birds[2].SetActive(false);
            GameController.instance.SetSelectdBird(0);
            birds[GameController.instance.GetSelectedBird()].SetActive(true);
        }
    }
}
