using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    public static GameController instance;

    private const string HIGH_SCORE = "Hight Score";
    private const string SELECTED_BIRD = "Selected Bird";
    private const string GREEN_BIRD  = "Green Bird";
    private const string RED_BIRD = "Red Bird";
    private const string BLUE_BIRD = "Blue Bird";


    void Awake()
    {
        MakeSingleton();

    }
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void MakeSingleton()
    {
        if(instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}
