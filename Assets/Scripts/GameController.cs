using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{

    public static GameController control;

    public bool player_isSpirit;

    void Awake()
    {
        if (control == null)
        {
            DontDestroyOnLoad(gameObject);
            control = this;
        }
        else if (control != this)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {

    }

    void Update()
    {

    }
}
