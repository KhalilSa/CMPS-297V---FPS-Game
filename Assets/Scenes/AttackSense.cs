using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class AttackSense : MonoBehaviour
{
    private bool canAttack;

    public bool Attackable { get; private set; }

    private void OnTriggerEnter(Collider other)
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
