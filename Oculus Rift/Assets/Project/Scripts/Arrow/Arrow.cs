using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour, IOnObjectSpawn
{
    public void Spawnded()
    {
        transform.parent = null;
       // transform.rotation = Quaternion.identity;
        Rigidbody rb =gameObject.AddComponent<Rigidbody>();
        GetComponent<Collider>().enabled =true;
        rb.AddForce(transform.forward * 35f,ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Ground")
        {
            ScoreScript.Instance.SetScore(-1);
            Destroy(GetComponent<Rigidbody>());
            ObjectPool.Instance.BackInBlack("Arrow",gameObject);
            //back to pool
        }
        if (collision.collider.tag == "Apple")
        {
            if (!collision.collider.GetComponent<Set10>().set10)
            {
                ScoreScript.Instance.SetScore(5);
                collision.collider.GetComponent<Set10>().set10 = true;
            }
            else
                ScoreScript.Instance.SetScore(10);
            GetComponent<Collider>().enabled = false;
            Destroy(GetComponent<Rigidbody>());
            transform.SetParent(collision.transform);
        }
        if (collision.collider.tag == "DestroyZone")
        {
            collision.gameObject.GetComponent<HighlightZone>().SpawnHalfs();
            ScoreScript.Instance.SetScore(10);
            Destroy(GetComponent<Rigidbody>());
            ObjectPool.Instance.BackInBlack("Arrow", gameObject);

        }
       
    }
}
