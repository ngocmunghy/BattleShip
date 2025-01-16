using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    public int index;
    public Vector2 localPos;
    public bool isColored;

    private void OnEnable()
    {
        
    }

    public void SetData(int index, Vector2 localPos, bool isColored)
    {
        this.index = index;
        this.localPos = localPos;
        this.isColored = isColored;
    }
}
