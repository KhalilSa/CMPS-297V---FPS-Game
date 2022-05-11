using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SightSense : MonoBehaviour
{
    public bool canSee;
    [SerializeField]
    private float _sightRange;

    public bool Seeable { get; private set; }
    public float SightRange { get; set; }

    private void Start()
    {
        if (SightRange > 0)
            GetComponent<SphereCollider>().radius = SightRange;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
            Seeable = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
            Seeable = false;
    }
}
