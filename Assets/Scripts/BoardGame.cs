using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardGame : SingletonDontDestroy<BoardGame>
{

    [SerializeField] GameObject cellPrefab;

    const int RESOLUTION = 8;

    //private Vector2 cellSize = new Vector2(100f, 100f);

    private float cellSize = 100f;
    private Vector2 baseSize;

    public List<Cell> cellList;

    void Start()
    {
        baseSize = new Vector2(cellSize / 2f, -cellSize / 2f);
        CreateBoard();
    }

    private void OnEnable()
    {
        ReturnPool();
    }

    void ReturnPool()
    {
        if (cellList != null)
        {
            cellList.Clear();
        }

        cellList = new List<Cell>();
    }

    void CreateBoard()
    {
        for (int i = 0; i < RESOLUTION; i++)
        {
            for (int j = 0; j < RESOLUTION; j++)
            {
                GameObject cellGO = SmartPool.Instance.Spawn(cellPrefab, Vector3.zero, Quaternion.identity);

                RectTransform rt = cellGO.GetComponent<RectTransform>();

                rt.anchorMin = new Vector2(0, 1);
                rt.anchorMax = new Vector2(0, 1);

                cellGO.transform.SetParent(transform);
                cellGO.transform.localScale = Vector3.one;
                cellGO.transform.localPosition = new Vector3(cellGO.transform.localPosition.x, cellGO.transform.localPosition.y, 0);
                //cellGO.transform.localPosition = new Vector2(cellSize * j, -cellSize * i) + baseSize;
                rt.anchoredPosition = new Vector2(cellSize * j, -cellSize * i) + baseSize;
                Cell cell = cellGO.GetComponent<Cell>();
                cell.SetData(i * RESOLUTION + j, new Vector2(cellGO.transform.localPosition.x, cellGO.transform.localPosition.y), false);
                cellList.Add(cell);
            }
        }
    }




    void Update()
    {
        
    }
}
