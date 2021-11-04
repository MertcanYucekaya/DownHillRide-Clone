using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSc : MonoBehaviour
{
    public float wallDestroyDuration;
    void Start()
    {
        Invoke("wallDestroy", wallDestroyDuration);
    }
    void wallDestroy()
    {
        Destroy(gameObject);
    }
}
