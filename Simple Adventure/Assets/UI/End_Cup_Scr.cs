using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End_Cup_Scr : MonoBehaviour
{
    [SerializeField] private LevelSceneInfo lsi;
    [SerializeField] private int startScore;
    [SerializeField] private int startHp;

    public Transform valueHeart;
    public Transform valueFruit;

    [SerializeField]
    int currentHp;
    // Start is called before the first frame update
    void Start()
    {
        startHp = (int)GameObject.Find("Player").GetComponent<Player>().maxHp;
        //startScore = (int)GameObject.Find("ValueFruit").GetComponent<RenderHeart>().allFruitsCounter;
        startScore = GameObject.FindGameObjectsWithTag("Fruits").Length;
        index = lsi.currentLevel;

    }

    [SerializeField]
    int index;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Animator anim = GetComponent<Animator>();
        anim.SetTrigger("Press");

        lsi.levels[index].isCompleted = true;
        lsi.levels[index].score = (int)GameObject.Find("ValueFruit").GetComponent<RenderHeart>().allFruitsCounter;
        rankSet();
    }

    public void rankSet()
    {
        
        // rank S = (getFullFruit + notHPLost)
        if (lsi.levels[index].score == 0 && currentHp == startHp)
        {
            lsi.levels[index].rank = Level_OOP.Ranks.S;
        }

        // rank A = (getFullFruit)
        if (lsi.levels[index].score == 0 && currentHp != startHp)
        {
            lsi.levels[index].rank = Level_OOP.Ranks.A;
        }

        //rank C = (score < startScore/2)
        if (lsi.levels[index].score != 0 && lsi.levels[index].score < startScore / 2)
        {
            lsi.levels[index].rank = Level_OOP.Ranks.C;
        }

        //rank D = (score > startScore/2)
        if (lsi.levels[index].score != 0 && lsi.levels[index].score >= startScore / 2)
        {
            lsi.levels[index].rank = Level_OOP.Ranks.D;
        }
    }
}
