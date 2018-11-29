using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleRotation : MonoBehaviour {

    Vector3 eulers;
	// Use this for initialization
	void Start () {
        float x = Random.Range(-1f, 1f);
        float y = Random.Range(-1f, 1f);
        float z = Random.Range(-1f, 1f);
        eulers = new Vector3(x, y, z);

    }
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(eulers.normalized * 100 * Time.deltaTime);
    }
}
