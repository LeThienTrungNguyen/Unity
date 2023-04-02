using UnityEngine;

public class NameChange : MonoBehaviour
{
    public string myname;
    // Start is called before the first frame update
    void Start()
    {
        transform.name = myname;
    }

}
