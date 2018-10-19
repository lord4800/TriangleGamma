using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EasyButtons;
using UnityEngine.UI;

public class RefAlphaScript : MonoBehaviour {

    [SerializeField, Range(0f,1f)]
    float alpha;
	[Button]
	void SetAlpha () {
        GetComponent<Image>().color = Color.white * alpha;
	}
    [Button]
    void ResetAlpha()
    {
        GetComponent<Image>().color = Color.white * 0;
    }
}
