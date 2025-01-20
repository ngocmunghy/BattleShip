using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockComp : MonoBehaviour
{
    public BlockItems blockItems;
    public BlockInteraction blockInter;
    public Cell nearestCell;
    Camera cam;
    Vector3 offsetFromFirstBlock;
    Vector3 offsetFromFirstTouch;

    void Start()
    {
        blockItems = GetComponentInParent<BlockItems>();
        blockInter = GetComponentInParent<BlockInteraction>();
        cam = Camera.main;
    }

    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if (!blockInter.canMoveBlock) return;
        blockInter.isHolding = true;
        Vector3 lastPos = transform.position;
        var screenPoint = Input.mousePosition;
        screenPoint.z = 10f;
        offsetFromFirstTouch = cam.ScreenToWorldPoint(screenPoint) - lastPos;
    }

    private void OnMouseUpAsButton()
    {
        if (!blockInter.canMoveBlock) return;
        blockInter.isHolding = false;
        if (CheckValidateBlock())
        {
            transform.position += offsetFromFirstBlock;
            blockInter.canMoveBlock = false;
        }
        else
        {
            blockInter.ResetPos();
        }
    }

    bool CheckValidateBlock()
    {
        nearestCell = GetNeareastCellByPosition(blockItems.GetFirstItemComp().transform.position);

        if (nearestCell == null || nearestCell.isColored == true)
        {
            return false;
        }

        BlockComp[] blockItemComps = blockItems.GetBlockItemComps();

        for (int i = 1; i < blockItemComps.Length; i++)
        {
            Cell cellInBoard = GetNeareastCellByPosition(blockItemComps[i].transform.position);

            if (cellInBoard == null || cellInBoard.isColored == true)
            {
                return false;
            }
        }

        return true;
    }

    public Cell GetNeareastCellByPosition(Vector3 pos)
    {

        float distance = Mathf.Sqrt(2 * 0.463f * 0.463f);

        for (int i = 0; i < BoardGame.Instance.cellList.Count; i++)
        {
            Cell cell = BoardGame.Instance.cellList[i];
            if (Vector2.Distance(cell.transform.position, pos) < distance)
            {
                offsetFromFirstBlock = cell.transform.position - pos;
                return cell;
            }
        }
        return null;
    }
}
