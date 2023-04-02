using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RankRender : MonoBehaviour
{
    public LevelSceneInfo lsi;
    public int level;
    public Level_OOP.Ranks rank;


    public string textRank;
    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (lsi.levels[level].rank == Level_OOP.Ranks.Zero)
        {
            textRank = "";
        }
        if (lsi.levels[level].rank == Level_OOP.Ranks.D)
        {
            textRank = "D";//363A3A
            text.text = textRank;
            text.color = ColorUtility.TryParseHtmlString("#363A3A", out Color color) ? color : Color.white;
        }
        if (lsi.levels[level].rank == Level_OOP.Ranks.C)
        {
            textRank = "C";//AAAB00
            text.color = ColorUtility.TryParseHtmlString("#AAAB00", out Color color) ? color : Color.white;
        }
        if (lsi.levels[level].rank == Level_OOP.Ranks.A)
        {
            textRank = "A";//00BE14
            text.color = ColorUtility.TryParseHtmlString("#00BE14", out Color color) ? color : Color.white;
        }
        if (lsi.levels[level].rank == Level_OOP.Ranks.S)
        {
            textRank = "S";//AA00BE
            text.color = ColorUtility.TryParseHtmlString("#AA00BE", out Color color) ? color : Color.white;
        }
        text.text = textRank;
    }
}
