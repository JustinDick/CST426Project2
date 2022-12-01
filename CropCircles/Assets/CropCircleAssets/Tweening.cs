using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tweening : MonoBehaviour
{
    // Start is called before the first frame update
    public void OnClose()
    {
        LeanTween.scale(gameObject, new Vector3(0, 0, 0), 0.5f).setOnComplete(DestroyMe);
    }

    // Update is called once per frame
    void DestroyMe()
    {
        Destroy(gameObject);
    }
}
