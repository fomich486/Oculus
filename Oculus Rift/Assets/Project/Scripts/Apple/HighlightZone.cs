using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightZone : MonoBehaviour {

    public void SpawnHalfs()
    {
        ObjectPool.Instance.GetFromPool("AppleHalf", transform.parent.position, Quaternion.identity);
        ObjectPool.Instance.GetFromPool("AppleHalf", transform.parent.position, Quaternion.identity);

        Transform parent = transform.parent;
        Transform arrowContainer = parent.GetChild(0);
        arrowContainer.GetComponent<Set10>().set10 = false;
        Arrow[] arrows = arrowContainer.GetComponentsInChildren<Arrow>();
        foreach (Arrow a in arrows)
        {
            a.gameObject.transform.parent = null;
            ObjectPool.Instance.BackInBlack("Arrow", a.gameObject);
        }
        ObjectPool.Instance.BackInBlack("Apple", parent.gameObject);
    }
}
