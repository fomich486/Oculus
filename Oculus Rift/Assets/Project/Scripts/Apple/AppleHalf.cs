using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleHalf : MonoBehaviour,IOnObjectSpawn {
    public void Spawnded()
    {
        Vector3 randomDirection = new Vector3(Random.value, Random.value, Random.value);
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.AddForce(randomDirection.normalized * 10f, ForceMode.Impulse);
        rb.AddTorque(randomDirection.normalized * 5f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Ground")
        {
            ObjectPool.Instance.BackInBlack("AppleHalf",gameObject);
        }
    }
}
