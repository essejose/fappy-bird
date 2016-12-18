using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneFader : MonoBehaviour {

    public static SceneFader instance;

    [SerializeField]
    private GameObject fadeCanvas;

    [SerializeField]
    private Animator fadeAnim;

    void Awake()
    {
        MakeSingleton();
    } 

    void MakeSingleton()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }


    public void FadeOut()
    {
        StartCoroutine(FadeOutAnimation());

    }
    public void FadeIn(string levelName)
    {
        StartCoroutine(FadeInAnimation(levelName));
    }

    IEnumerator FadeInAnimation(string levelName)
    {
        fadeCanvas.SetActive(true);
        fadeAnim.Play("FadeIn");
        yield return new WaitForSeconds(.7f);
         SceneManager.LoadScene(levelName);
        FadeOut();

    }

    IEnumerator FadeOutAnimation()
    {
        fadeAnim.Play("FadeInOut");
        yield return new WaitForSeconds(1f);
        fadeCanvas.SetActive(false);

    }
}
