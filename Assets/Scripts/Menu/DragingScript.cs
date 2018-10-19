using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragingScript : MonoBehaviour {
    public Transform recordT;
    public Transform exitT;
    public Transform settingsT;

    public Transform themsT;
    public Transform tutorialT;
    public Transform informationT;

    [SerializeField]
    float maxDistance;
    [SerializeField]
    float speed;

    Vector3 _stRecordT;
    Vector3 _stExitT;
    Vector3 _stSettingsT;

    Vector3 _stThemsT;
    Vector3 _stTutorialT;
    Vector3 _stInformationT;

    // Use this for initialization
    void Start () {
        SaveStartPos();
	}
	
	// Update is called once per frame
	void Update () {
        DragAllElements();
    }

    void DragAllElements()
    {
        DragElement(recordT,_stRecordT);
        DragElement(exitT, _stExitT);
        DragElement(settingsT, _stSettingsT);
        DragElement(themsT, _stThemsT);
        DragElement(tutorialT, _stTutorialT);
        DragElement(informationT, _stInformationT);

    }

    void DragElement(Transform element, Vector3 startPos)
    {
        if (Vector3.Distance(startPos, element.position) > maxDistance)
        {
            //make move Inside
            MakeMoveInside(element, startPos);
        }
        else
        {
            //make random move
            MakeRandomMove(element);
        }
    }
    void MakeMoveInside(Transform element, Vector3 startPos)
    {
        element.position = Vector3.Lerp(element.position, element.position + (startPos - element.position).normalized, Time.smoothDeltaTime * speed);
    }


    void MakeRandomMove(Transform element)
    {
        element.position = Vector3.Lerp(element.position,element.position + EpsilonVec().normalized,Time.smoothDeltaTime * speed);
    }

    Vector3 EpsilonVec()
    {
        float x = Random.Range(-1, 1f);
        float y = Random.Range(-1, 1f);
        //Debug.Log(x + " : " + y);
        return new Vector3(x, y, 0);
    }

    void SaveStartPos()
    {
        _stRecordT = recordT.position;
        _stExitT = exitT.position;
        _stSettingsT = settingsT.position;
        _stThemsT = themsT.position;
        _stTutorialT = tutorialT.position;
        _stInformationT = informationT.position;
    }
}
