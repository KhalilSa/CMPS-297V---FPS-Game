using UnityEngine;

public class AttackSense : MonoBehaviour
{
    private bool canAttack;
    private float _attackRange;

    public bool Attackable { get; private set; }
    public float AttackRange { get; set; }

    private void Start()
    {
        if (AttackRange > 0)
            GetComponent<SphereCollider>().radius = AttackRange;
    }

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
