using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaderSizeChangin : MonoBehaviour
{
    public RenderTexture texture;
    void Start()
    {
        texture.height = Screen.height;
        texture.width = Screen.width;
    }

}
