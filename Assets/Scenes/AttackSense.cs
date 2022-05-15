using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class AttackSense : MonoBehaviour
{
    public bool Attackable { get; private set; }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
            Attackable = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
            Attackable = false;
    }
}
