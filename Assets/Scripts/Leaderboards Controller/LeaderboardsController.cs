﻿using UnityEngine;
using System.Collections; 
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;
 
public class LeaderboardsController : MonoBehaviour {

    public static LeaderboardsController instance;

    private const string LEADERBOARDS_SCORE = "CgkIn5nJuIQbEAIQBA ";

    void Awake()
    {
        MakeSingleton();
    }

    void Start()
    { 
        PlayGamesPlatform.Activate();
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

    void OnLevelWasLoaded()
    {
        //ReportScore(GameController.instance.GetHighscore());
    }

    public void ConnectGooglePlayGames()
    {
        /*if (Social.localUser.authenticated)
        {
            Social.localUser.Authenticate((bool sucess) => {
               
            });
        }*/

        if (!Social.localUser.authenticated)
        {
            Social.localUser.Authenticate((bool sucess) => {
                Debug.Log(sucess);
            });
        }
           

    }

    public void OpenLeaderboardsScore()
    {
        Social.ShowLeaderboardUI();
        if (Social.localUser.authenticated)
        {
            PlayGamesPlatform.Instance.ShowLeaderboardUI(LEADERBOARDS_SCORE);
        }
    }

    void ReportScore(int score)
    {
        if (Social.localUser.authenticated)
        {
            Social.ReportScore(score, LEADERBOARDS_SCORE, (bool sucess) =>
              {

              });
        }
    }

}
