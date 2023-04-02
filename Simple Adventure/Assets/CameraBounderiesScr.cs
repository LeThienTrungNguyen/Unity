using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBounderiesScr : MonoBehaviour
{
    public Camera cam;
    [SerializeField] Transform []positions;
    [SerializeField] Vector2 pos0;
    [SerializeField] Vector2 pos1;

    public bool priorityLeft;
    public bool priorityDown;
    // Start is called before the first frame update
    private void Update()
    {
        pos0 = cam.GetComponent<FollowTarget>().clampPosition_0;
        pos1 = cam.GetComponent<FollowTarget>().clampPosition_1;
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        SetBoundariesPosition(collision);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        SetBoundariesPosition(collision);

    }

    void SetBoundariesPosition(Collider2D collision)
    {
        float finalClampX_0 =0;
        float finalClampX_1 = 0;
        float finalClampY_0 = 0;
        float finalClampY_1 = 0;
        if (collision.tag == "Player")
        {
            float heightCam = cam.orthographicSize;
            float widthCam = heightCam * cam.aspect;

            if (positions[0].position.x + widthCam > positions[1].position.x - widthCam)
            {
                if (priorityLeft)
                {
                    finalClampX_0 = positions[0].position.x + widthCam;
                    finalClampX_1 = positions[1].position.x;
                } else
                {
                    finalClampX_0 = positions[0].position.x ;
                    finalClampX_1 = positions[1].position.x - widthCam;
                }
            } else
            {
                finalClampX_0 = positions[0].position.x + widthCam;
                finalClampX_1 = positions[1].position.x - widthCam;
            }

            if (positions[0].position.x + widthCam > positions[1].position.x - widthCam)
            {
                if (priorityDown)
                {
                    finalClampY_0 = positions[0].position.y + heightCam;
                    finalClampY_1 = positions[1].position.y;
                }
                else
                {
                    finalClampY_0 = positions[0].position.y ;
                    finalClampY_1 = positions[1].position.y - heightCam;
                }
            } else
            {
                finalClampY_0 = positions[0].position.y + heightCam;
                finalClampY_1 = positions[1].position.y - heightCam;
            }


            cam.GetComponent<FollowTarget>().clampPosition_0 = new Vector2(finalClampX_0, positions[0].position.y + heightCam);
            cam.GetComponent<FollowTarget>().clampPosition_1 = new Vector2(finalClampX_1, positions[1].position.y - heightCam);


            /*
            cam.GetComponent<FollowTarget>().clampPosition_0 = new Vector2(positions[0].position.x + widthCam, positions[0].position.y + heightCam);
            cam.GetComponent<FollowTarget>().clampPosition_1 = new Vector2(positions[1].position.x - widthCam, positions[1].position.y - heightCam);*/
        }
    }
}
