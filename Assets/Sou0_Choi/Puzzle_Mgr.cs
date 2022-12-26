using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Puzzle_Mgr : MonoBehaviour
{
    public List<Tile> EntireTiles = new List<Tile>();
    public Tile NowTiles;
    [SerializeField] private int HorziontalMax;
    [SerializeField] private int VerticalMax;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveNowTile();
        TurnTile();
        Debug.Log(NowTiles.gameObject.transform.eulerAngles.z % 90 == 0);
        Debug.Log(NowTiles.gameObject.transform.eulerAngles.z % 90);
        Debug.Log(NowTiles.gameObject.transform.eulerAngles.z);
    }

    private void MoveNowTile()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (NowTiles.VerticalNum == 1)
                Debug.Log("못올라가요");
            else
                ChangeNowTile(NowTiles.HorizontalNum, NowTiles.VerticalNum - 1);

        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            if (NowTiles.VerticalNum == VerticalMax)
                Debug.Log("못내려가요");
            else
                ChangeNowTile(NowTiles.HorizontalNum, NowTiles.VerticalNum + 1);
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            if (NowTiles.HorizontalNum == 1)
                Debug.Log("왼쪽으로 못 가요");
            else
                ChangeNowTile(NowTiles.HorizontalNum - 1, NowTiles.VerticalNum);
        }
        else if (Input.GetKeyDown (KeyCode.D))
        {
            if (NowTiles.HorizontalNum == HorziontalMax)
                Debug.Log("오른쪽으로 못 가요");
            else
                ChangeNowTile(NowTiles.HorizontalNum + 1, NowTiles.VerticalNum);
        }

    }

    private void TurnTile()
    {
        if (Input.GetKeyDown(KeyCode.Space) && 
            (NowTiles.gameObject.transform.eulerAngles.z % 90 == 0 || 
            NowTiles.gameObject.transform.eulerAngles.z % 90 <= 1.1))
        {
            NowTiles.gameObject.transform.DORotateQuaternion(Quaternion.Euler(0, 0, NowTiles.gameObject.transform.eulerAngles.z + 90), 1);
        }
    }

    private void ChangeNowTile(int Horizontal, int Vertical)
    {
        for (int i = 0; i < EntireTiles.Count; i++)
        {
            if (EntireTiles[i].HorizontalNum == Horizontal && 
                EntireTiles[i].VerticalNum == Vertical)
                NowTiles = EntireTiles[i];
        }
    }
}
