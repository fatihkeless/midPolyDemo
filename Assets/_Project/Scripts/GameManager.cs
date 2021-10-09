using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    //kontrol komutumuzu yazalým
    //Let's write our control command

    public static GameManager instance = null;
    public FollowLine robot = null;



    private void Awake()
    {
        instance = this;   
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
