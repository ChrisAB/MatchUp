using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScaler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        float width = ScreenSize.GetScreenToWorldWidth;
        float height = ScreenSize.GetScreenToWorldHeight;
        transform.localScale = new Vector3(1*width, 1*height, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
