using UnityEngine;

public class Rotator : MonoBehaviour
{
    void Start()
    {
        var rb = GetComponent<Rigidbody>();
        rb.angularVelocity = Random.insideUnitSphere;
    }
}
