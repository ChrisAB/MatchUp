using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBGScaler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        float width = ScreenSize.GetScreenToWorldWidth;
        float height = ScreenSize.GetScreenToWorldHeight;
        transform.localScale = new Vector3(1f*width, height*0.175f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
