using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikedBall_Pendulum : MonoBehaviour
{
    public float amplitude = 45f;
    public float speed = 2f;
    public float switchTime = 2f;

    private float angle = 0f;
    private float timer = 0f;
    private bool isSwitched = false;

    void Update()
    {
        angle += speed * Time.deltaTime;
        if (angle >= Mathf.PI * 2f)
        {
            angle = 0f;
            isSwitched = false;
        }

        if (!isSwitched && timer > switchTime)
        {
            speed *= -1f;
            isSwitched = true;
            timer = 0f;
        }

        transform.rotation = Quaternion.Euler(0f, 0f, amplitude * Mathf.Sin(angle));

        timer += Time.deltaTime;
    }
}
