using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockInteraction : MonoBehaviour
{

    Camera cam;
    BlockItems blockItems;

    Vector3 offsetFromFirstTouch;
    Vector3 offsetFromFirstBlock;

    public Cell nearestCell;

    Vector3 basePosBlock;

    public bool isHolding;
    public bool canMoveBlock;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        blockItems = GetComponent<BlockItems>();
    }

    //private void OnEnable()
    //{
    //    isHolding = false;
    //    canMoveBlock = true;
    //    basePosBlock = transform.position;
    //}

    //void Update()
    //{

    //    if (!canMoveBlock)
    //        return;

    //    if (isHolding)
    //    {
    //        var screenPoint = Input.mousePosition;
    //        screenPoint.z = 10.0f; //distance of the plane from the camera
    //        transform.position = cam.ScreenToWorldPoint(screenPoint) - offsetFromFirstTouch;
    //    }
    //}

    //private void OnMouseDown()
    //{
    //    if (!canMoveBlock) return;
    //    isHolding = true;
    //    Vector3 lastPos = transform.position;
    //    var screenPoint = Input.mousePosition;
    //    screenPoint.z = 10f;
    //    offsetFromFirstTouch = cam.ScreenToWorldPoint(screenPoint) - lastPos;
    //}

    //private void OnMouseUpAsButton()
    //{
    //    if (!canMoveBlock) return;
    //    isHolding = false;
    //    if (CheckValidateBlock())
    //    {
    //        transform.position += offsetFromFirstBlock;
    //        canMoveBlock = false;
    //    } else
    //    {
    //        ResetPos();
    //    }
    //}

    public void ResetPos()
    {
        transform.position = basePosBlock;
    }

    //bool CheckValidateBlock()
    //{
    //    nearestCell = GetNeareastCellByPosition(blockItems.GetFirstItemComp().transform.position);

    //    if (nearestCell == null || nearestCell.isColored == true)
    //    {
    //        return false;
    //    }

    //    BlockComp[] blockItemComps = blockItems.GetBlockItemComps();
        
    //    for (int i = 1; i < blockItemComps.Length; i++)
    //    {
    //        Cell cellInBoard = GetNeareastCellByPosition(blockItemComps[i].transform.position);

    //        if (cellInBoard == null || cellInBoard.isColored == true)
    //        {
    //            return false;
    //        }
    //    }

    //    return true;
    //}

    //public Cell GetNeareastCellByPosition(Vector3 pos)
    //{

    //    float distance = Mathf.Sqrt(2 * 0.463f * 0.463f);

    //    for (int i = 0; i < BoardGame.Instance.cellList.Count; i++)
    //    {
    //        Cell cell = BoardGame.Instance.cellList[i];
    //        if (Vector2.Distance(cell.transform.position, pos) < distance)
    //        {
    //            offsetFromFirstBlock = cell.transform.position - pos;
    //            return cell;
    //        }
    //    }
    //    return null;
    //}
}
