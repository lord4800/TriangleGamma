using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragingScript : MonoBehaviour {
    public Transform recordButton;
    public Transform exitButton;
    public Transform settingsButton;

    public Transform themsButton;
    public Transform tutorialButton;
    public Transform informationButton;

    [SerializeField]
    float maxDistance;
    [SerializeField]
    float speed;

    Vector3 startRecordPosition;
    Vector3 startExitPosition;
    Vector3 startSettingsPosition;

    Vector3 startThemsPosition;
    Vector3 startTutorialPosition;
    Vector3 startInformationPosition;

    void Start () {
        SaveStartPos();
	}
	
	void Update () {
        DragAllElements();
    }

    void DragAllElements()
    {
        DragElement(recordButton,startRecordPosition);
        DragElement(exitButton, startExitPosition);
        DragElement(settingsButton, startSettingsPosition);
        DragElement(themsButton, startThemsPosition);
        DragElement(tutorialButton, startTutorialPosition);
        DragElement(informationButton, startInformationPosition);

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
        return new Vector3(x, y, 0);
    }

    void SaveStartPos()
    {
        startRecordPosition = recordButton.position;
        startExitPosition = exitButton.position;
        startSettingsPosition = settingsButton.position;
        startThemsPosition = themsButton.position;
        startTutorialPosition = tutorialButton.position;
        startInformationPosition = informationButton.position;
    }
}
