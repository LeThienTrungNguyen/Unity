using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform_Scr : MonoBehaviour
{
    public Transform posA;
    public Transform posB;
    public float speed;

    public List<Transform> positions;

    Transform target;
    // Start is called before the first frame update
    void Start()
    {
        target = posA;
    }

    // Update is called once per frame
    void Update()
    {

        //
        if (Vector2.Distance(transform.position, posA.position) < 0.1f) target = posB;
        if (Vector2.Distance(transform.position, posB.position) < 0.1f) target = posA;

        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.transform.SetParent(null);
        }
    }
}
