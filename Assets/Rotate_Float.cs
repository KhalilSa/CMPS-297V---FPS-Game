using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate_Float: MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 pos;
    void Start()
    {
        pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * 50 * Time.deltaTime, Space.Self);
    }
}
