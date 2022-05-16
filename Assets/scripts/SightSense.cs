using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class SightSense : MonoBehaviour
{
    public bool Seeable { get; private set; }

    private void OnTriggerStay(Collider other)
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
