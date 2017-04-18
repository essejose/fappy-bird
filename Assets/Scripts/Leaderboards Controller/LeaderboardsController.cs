using UnityEngine;
using System.Collections; 
//using GooglePlayGames;
//using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;
 
public class LeaderboardsController : MonoBehaviour {

    public static LeaderboardsController instance;

    private const string LEADERBOARDS_SCORE = "CgkIn5nJuIQbEAIQBg";

    void Awake()
    {
        MakeSingleton();

        //PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder()
        // enables saving game progress.
        // .EnableSavedGames()

        // .RequireGooglePlus()
        //.Build();
 

    }

    void Start()
    {
         //StartCoroutine(SocialLogin());
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

    // void OnLevelWasLoaded()
    //{
    //ReportScore(GameController.instance.GetHighscore());
    //}
    /*IEnumerator SocialLogin()
    {

        yield return null;

        PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder()
            // enables saving game progress.
            .EnableSavedGames()
                .Build();

        PlayGamesPlatform.InitializeInstance(config);
        // recommended for debugging:
        //PlayGamesPlatform.DebugLogEnabled = true;

        yield return null;

        // Activate the Google Play Games platform
        PlayGamesPlatform.Activate();

        yield return null;

        // authenticate user:
        Social.localUser.Authenticate(playAuthenticate);

    }
    */
    private void playAuthenticate(bool success)
    {
    //    Debug.Log("Authentication result " + success);
    }
    public void ConnectGooglePlayGames()
    {

      /*  Debug.Log(Social.localUser.authenticated);
        if (Social.localUser.authenticated)
        {
            Social.localUser.Authenticate((bool sucess) => {
                Debug.Log(sucess);
            });
        }

        if (!Social.localUser.authenticated)
        {
            Social.localUser.Authenticate((bool sucess) => {
                Debug.Log(sucess);
            });
        }
           
        */
    }

    public void OpenLeaderboardsScore()
    {
       /* PlayGamesPlatform.Instance.ShowLeaderboardUI(LEADERBOARDS_SCORE);   
        if (Social.localUser.authenticated)
        {
            PlayGamesPlatform.Instance.ShowLeaderboardUI(LEADERBOARDS_SCORE);
        }*/
    }

    void ReportScore(int score)
    {
        /*if (Social.localUser.authenticated)
        {
            Social.ReportScore(score, LEADERBOARDS_SCORE, (bool sucess) =>
              {

              });
        }*/
    }

}
