using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour {
    public static ScoreCounter instance { get { return _instance; } }
    static ScoreCounter _instance;
    public AnimationCurve changeScoreAnim;
    [SerializeField]
    float animTime;
    Text counterText;
    int count = 0;
	// Use this for initialization
	void Start () {
        _instance = this;
        counterText = GetComponent<Text>();
        count = 0;
        ShowScore();
	}

    public void AddCounter()
    {
        count++;
        ShowScore();
    }

    public void NegCounter()
    {
        count--;
        ShowScore();
    }

    void ShowScore()
    {
        counterText.text = count.ToString();
        StartCoroutine(ChangeAnim());
    }

    IEnumerator ChangeAnim()
    {
        for (float f = 0; f < animTime; f += Time.smoothDeltaTime)
        {
            yield return null;
            transform.localScale = Vector3.one * changeScoreAnim.Evaluate(f/animTime);
        }
        yield return null;
        transform.localScale = Vector3.one;
    }

}
