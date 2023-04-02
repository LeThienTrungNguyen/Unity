using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class RenderHeart : MonoBehaviour
{
    public Sprite[] listNumberImage;
    public Sprite currentImage;
    [SerializeField]Player player;
    [SerializeField] public float allFruitsCounter;
    [SerializeField] public int currentHp;
    // Start is called before the first frame update
    void Start()
    {
        //currentImage = GetComponent<Image>().sprite;
        GameObject objectPlayer = GameObject.FindGameObjectWithTag("Player");
        player = objectPlayer.GetComponent<Player>();
        
    }

    // Update is called once per frame
    void Update()
    {
        RerenderImage();
    }

    void RerenderImage()
    {
        currentHp = player.getCurrentHP();
        allFruitsCounter = GameObject.FindGameObjectsWithTag("Fruits").Length;
        if (transform.tag == "Heart") transform.GetComponent<Text>().text = currentHp.ToString();
        if (transform.tag == "Score") transform.GetComponent<Text>().text = allFruitsCounter.ToString(); 
        /*if (currentHp <= listNumberImage.Length + 1)
        {
            currentImage = listNumberImage[currentHp];
            GetComponent<Image>().sprite = currentImage;
        }*/
    }
}
