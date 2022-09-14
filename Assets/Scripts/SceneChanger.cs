using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SceneChanger : MonoBehaviour
{
    // Start() and Update() methods deleted - we don't need them right now

    public static SceneChanger Instance;

    private void Awake()
    {
        // start of new code
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        // end of new code

        Instance = this;
        DontDestroyOnLoad(gameObject);
        //LoadColor();
    }
}
