using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ListBackGround : MonoBehaviour
{
    public List<Texture> listBackground = new List<Texture>();
    public RawImage rawImage;
    // Start is called before the first frame update
    void Start()
    {
        RandomBackground();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void RandomBackground()
    {
        int index = Random.Range(0, listBackground.Count);
        rawImage.texture = listBackground[index];
    }
}
