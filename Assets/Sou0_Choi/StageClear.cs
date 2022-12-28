using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Clear
{
    public Tile ClearTile;
    public int ClearRotation;
}

public class StageClear : MonoBehaviour
{
    [SerializeField] private List<Clear> ClearList = new List<Clear>();
    [SerializeField] private int MaxComplete;
    [SerializeField] private int Complete;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        Clear();
    }

    protected void Clear()
    {
        for (int i = 0; i < ClearList.Count; i++)
        {
            if (ClearList[i].ClearTile.gameObject.transform.rotation.z == ClearList[i].ClearRotation)
            {
                Complete++;
            }
            else
            {
                if (Complete > 0)
                    Complete--;
            }
        }

        if (Complete == MaxComplete)
            Debug.Log("Clear");
    }
}
