using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    public float spinSpeed;
    public GameObject obj;

    // Update is called once per frame
    void Update()
    {
        obj.transform.rotation = Quaternion.Euler(new Vector3(0, obj.transform.localEulerAngles.y + spinSpeed, 0));
    }
}
