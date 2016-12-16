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
        PlayerPrefs.DeleteAll();
        isTheGameStartedForTheFirstTime();
       
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

    void isTheGameStartedForTheFirstTime()
    {
        if (!PlayerPrefs.HasKey("isTheGameStartedForTheFirstTime"))
        {
            PlayerPrefs.SetInt(HIGH_SCORE,0);
            PlayerPrefs.SetInt(SELECTED_BIRD, 0);
            PlayerPrefs.SetInt(GREEN_BIRD, 1);
            PlayerPrefs.SetInt(RED_BIRD,1);
            PlayerPrefs.SetInt(BLUE_BIRD, 1);
            PlayerPrefs.SetInt("isTheGameStartedForTheFirstTime", 0);

        }
    }

    public void SetHighscore(int score)
    {
        PlayerPrefs.SetInt(HIGH_SCORE, score);
    }
    public int GetHighscore()
    {
        return PlayerPrefs.GetInt(HIGH_SCORE);
    }

    public void SetSelectdBird(int selectedbird)
    {
        PlayerPrefs.SetInt(SELECTED_BIRD, selectedbird);
    }
    public int GetSelectedBird()
    {
        return PlayerPrefs.GetInt(SELECTED_BIRD);
    }

    public void UnlockGreenBird()
    {
        PlayerPrefs.SetInt(GREEN_BIRD, 1);
    }

    public int isGreenBirdUnlocked()
    {
        return PlayerPrefs.GetInt(GREEN_BIRD);
    }

    public void UnlockRedBird()
    {
        PlayerPrefs.SetInt(RED_BIRD, 1);
    }

    public int isRedBirdUnlocked()
    {
        return PlayerPrefs.GetInt(RED_BIRD);
    }

    public void UnlockBlueBird()
    {
        PlayerPrefs.SetInt(BLUE_BIRD, 1);
    }

    public int isBlueBirdUnlocked()
    {
        return PlayerPrefs.GetInt(BLUE_BIRD);
    }


}
