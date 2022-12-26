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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
