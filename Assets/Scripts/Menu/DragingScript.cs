using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragingScript : MonoBehaviour {
    [SerializeField] private float maxDistance;
    [SerializeField] private float speed;
    [SerializeField] private List<Transform> buttonsTransforms = new List<Transform>();

    private List<Vector3> startButtonsPositions = new List<Vector3>();

    void Start () {
        SaveStartPos();
	}
	
	void Update () {
        DragAllElements();
    }

    void DragAllElements()
    {
        for (int i = 0; i < buttonsTransforms.Count; i++)
        {
            Transform element = buttonsTransforms[i];
            DragElement(element, startButtonsPositions[i]);
        }
    }

    void DragElement(Transform element, Vector3 startPos)
    {
        if (Vector3.Distance(startPos, element.position) > maxDistance)
        {
            MakeMoveInside(element, startPos);
        }
        else
        {
            MakeRandomMove(element);
        }
    }
    void MakeMoveInside(Transform element, Vector3 startPos)
    {
        element.position = Vector3.Lerp(element.position, element.position + (startPos - element.position).normalized, Time.smoothDeltaTime * speed);
    }


    void MakeRandomMove(Transform element)
    {
        element.position = Vector3.Lerp(element.position, element.position + EpsilonVec().normalized, Time.smoothDeltaTime * speed);
    }

    Vector3 EpsilonVec()
    {
        float x = Random.Range(-1, 1f);
        float y = Random.Range(-1, 1f);
        return new Vector3(x, y, 0);
    }

    void SaveStartPos()
    {
        foreach (var element in buttonsTransforms)
            startButtonsPositions.Add(element.position);
    }
}
