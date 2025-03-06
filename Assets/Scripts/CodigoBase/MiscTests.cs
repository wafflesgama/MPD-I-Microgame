using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiscTests : MonoBehaviour
{

    public float speed;
    public float oscilation=1f;
    public float rotation = 5f;

    private void Update()
    {
        transform.position += new Vector3(speed, Mathf.Sin(Time.time* oscilation), 0) * Time.deltaTime;

        //transform.eulerAngles += new Vector3(0, 0, rotation) * Time.deltaTime;

        transform.eulerAngles += new Vector3(0, 0, Mathf.Sin(Time.time* oscilation) *rotation) * Time.deltaTime;
    }
}
