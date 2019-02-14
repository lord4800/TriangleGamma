using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ParticleManagerScr : MonoBehaviour
{
    private const int pullSize = 5;
    static public ParticleManagerScr instance { get; set;}

    [SerializeField] private GameObject particlePrefab;

    [SerializeField] private Color green;
    [SerializeField] private Color yellow;
    [SerializeField] private Color red;

    private List<ParticleSystem> particlePull = new List<ParticleSystem>();
    private int currentIndex;
    
    // Use this for initialization
    void Start ()
    {
	    instance = this;
        for(int i = 0; i < pullSize; i++)
        {
            GameObject particle = Instantiate(particlePrefab);
            particlePull.Add(particle.GetComponent<ParticleSystem>());
        }
	}

    public void SetParticle(Vector3 pos, BonusType type)
    {
        currentIndex--;
        if (currentIndex < 0)
            currentIndex = particlePull.Count-1;
        particlePull[currentIndex].gameObject.SetActive(false);
        particlePull[currentIndex].transform.position = pos;
        ParticleSystem ps = particlePull[currentIndex];
        ParticleSystem.MainModule ma = ps.main;
        switch (type)
        {
            case BonusType.money:
                ma.startColor = yellow;
                break;
            case BonusType.negative:
                ma.startColor = red;
                break;
            case BonusType.positive:
                ma.startColor = green;
                break;
        }
        particlePull[currentIndex].gameObject.SetActive(true);

    }
}
