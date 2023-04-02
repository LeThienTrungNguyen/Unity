using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepairPosition : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }
    private void FixedUpdate()
    {
        transform.position = new Vector3(Mathf.RoundToInt(transform.position.x) - 0.5f, Mathf.RoundToInt(transform.position.y) - 0.5f, Mathf.RoundToInt(transform.position.z));
    }
}
