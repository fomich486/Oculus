using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleChangePosition : MonoBehaviour {
    [SerializeField]
    [Range(0.01f, 10f)]
    float timeToReachTarget;
    float timeBetweenChanges;
    float nextChangeTime;

    private void Start()
    {
        timeBetweenChanges = Random.Range(2f*60f, 4f*60f);
        nextChangeTime = Time.time + timeBetweenChanges;
    }

    void Update()
    {
        if (Time.time > nextChangeTime)
        {
            timeBetweenChanges = Random.Range(2f * 60f, 4f * 60f);
            nextChangeTime = Time.time + timeBetweenChanges;
            StartCoroutine(ChangePos());
        }
	}

    IEnumerator ChangePos()
    {
        float t = 0f;
        Vector3 startPosition = transform.position;
        Vector3 newPosition = AppleRandomPosition.GetPosition();
        while (t < 1)
        {
            transform.position = Vector3.Lerp(startPosition, newPosition, t);
            t += Time.deltaTime / timeToReachTarget;
            yield return null;
        }
        transform.position = newPosition;
    }
}
