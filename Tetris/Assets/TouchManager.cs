using UnityEngine;

public class TouchManager : MonoBehaviour
{
    public GameObject emptyObjectPrefab;

    private void Update()
    {
        GameObject emptyObject = null;
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            touchPosition.z = 0;

            emptyObject = GameObject.Find("Empty");
            if(emptyObject == null)
            {
                emptyObject = Instantiate(emptyObjectPrefab, touchPosition, Quaternion.identity);
            }
            
        }
        else if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            // 
            Destroy(emptyObject);
        }
    }
}