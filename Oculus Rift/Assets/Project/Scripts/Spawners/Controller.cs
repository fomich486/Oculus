using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {

    LineRenderer lr;
    void Start()
    {
        lr = GetComponent<LineRenderer>();
    }
        void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            Quaternion q = new Quaternion(0f, transform.rotation.y, transform.rotation.z, transform.rotation.w);
            ObjectPool.Instance.GetFromPool("Arrow", transform.position, q);
        }
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity))
        {
            lr.SetPosition(0, transform.position);
            lr.SetPosition(1, hit.point);
        }
        else {
            lr.SetPosition(0, transform.position);
            lr.SetPosition(1, transform.forward*100f);
        }

	}
}
