using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockItems : MonoBehaviour
{
    [SerializeField] BlockComp[] comps;
    [SerializeField] Vector2[] offsetIndexes;

    public BlockComp[] GetBlockItemComps()
    {
        return comps;
    }

    public BlockComp GetFirstItemComp()
    {
        return comps[0];
    }

    public Vector2[] GetOffsetIndexes()
    {
        return offsetIndexes;
    }
}
