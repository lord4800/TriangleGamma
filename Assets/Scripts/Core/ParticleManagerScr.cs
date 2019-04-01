using System.Collections.Generic;
using UnityEngine;
public class ParticleManager : MonoBehaviour
{
    private const int pullSize = 5;
    static public ParticleManager instance { get; set;}

    [SerializeField] private GameObject particlePrefab;
    [SerializeField] private Color green;
    [SerializeField] private Color yellow;
    [SerializeField] private Color red;

    private List<ParticleSystem> particlePull = new List<ParticleSystem>();
    private int currentIndex;
    
    void Start ()
    {
	    instance = this;
        for(int i = 0; i < pullSize; i++)
        {
            GameObject particle = Instantiate(particlePrefab);
            particlePull.Add(particle.GetComponent<ParticleSystem>());
        }
	}

    public void SetParticle(Vector3 pos, ColorType type)
    {
        currentIndex--;

        if (currentIndex < 0)
            currentIndex = particlePull.Count - 1;

        particlePull[currentIndex].gameObject.SetActive(false);
        particlePull[currentIndex].transform.position = pos;
        ParticleSystem ps = particlePull[currentIndex];
        ParticleSystem.MainModule ma = ps.main;
        SetColor(type, ma);
        particlePull[currentIndex].gameObject.SetActive(true);
    }

    private void SetColor(ColorType type, ParticleSystem.MainModule ma)
    {
        switch (type)
        {
            case ColorType.yellow:
                ma.startColor = yellow;
                break;
            case ColorType.red:
                ma.startColor = red;
                break;
            case ColorType.green:
                ma.startColor = green;
                break;
        }
    }
}
