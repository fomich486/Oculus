using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleRandomPosition : MonoBehaviour {

    public static Vector3 GetPosition()
    {
        float angle = Random.Range(-Mathf.PI, Mathf.PI);
        float distance = Random.Range(6f, 10f);
        Vector3 position = new Vector3(Mathf.Cos(angle), 0f, Mathf.Sin(angle)) * distance;
        position = new Vector3(position.x, Random.Range(1f,1.25f), position.z);
        return position;
    }
}
