using UnityEngine;
using System.Collections;

public class loading_level : MonoBehaviour
{
    private int pRounded;
    public Texture2D Main;
    public Texture2D poloska_1, poloska_2;

    static public string Name_of_Scene;

    void Start()
    {
        StartCoroutine("launchLevel");
    }

    IEnumerator launchLevel()
    {
        //MineMenuVar2
        AsyncOperation async = Application.LoadLevelAsync(Name_of_Scene); 
        //async.allowSceneActivation = false;
        while (async.isDone == false)
        {
            float p = async.progress * 100f;
            pRounded = Mathf.RoundToInt(p);
            string perc = pRounded.ToString();

            Debug.Log("Loading: " + perc + " %.");

            yield return true;
        }
    }

    void OnGUI()
    {
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), Main);
       // GUI.DrawTexture(new Rect(Screen.width / 8f, Screen.height / 1.15f, Screen.width / 1.33f , Screen.height / 30), poloska_1);
        GUI.DrawTexture(new Rect(Screen.width / 6.25f, Screen.height / 1.105f, Screen.width / 125f * pRounded, Screen.height/34), poloska_2);
    }
}

