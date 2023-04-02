using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    public Transform target;
    public float followSpeed;
    public Vector2 clampPosition_0;
    public Vector2 clampPosition_1;

    public Transform []cameraBoundaries;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position != target.position)
        {
            Vector3 newPos = new Vector3(target.position.x, target.position.y, -10);
            Vector3 targetPosition = target.position;
            newPos.x = Mathf.Clamp(newPos.x,clampPosition_0.x, clampPosition_1.x);
            newPos.y = Mathf.Clamp(newPos.y,clampPosition_0.y, clampPosition_1.y);
            //transform.position.y = Mathf.Clamp(target.position.y, clampPosition_0.y, clampPosition_1.y);
            transform.position =  Vector3.Lerp(transform.position, newPos, followSpeed * Time.deltaTime);
        }

        
    }
}
