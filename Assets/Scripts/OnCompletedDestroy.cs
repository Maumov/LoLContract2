using UnityEngine;
using System.Collections;

public class OnCompletedDestroy : MonoBehaviour
{
    public bool isAnimation;
    public float delay;

    private void Start()
    {
        if (isAnimation)
        {
            Destroy(gameObject, delay);
        }
        else
        {
            Destroy(gameObject, GetComponent<ParticleSystem>().duration);
        }
    }
}