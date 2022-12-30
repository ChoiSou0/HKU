using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ClearCheck;

[System.Serializable]
public class Clear
{
    public Tile ClearTile;
    public int ClearRotation;
}

public class StageClear : MonoBehaviour
{
    public List<Clear> ClearList = new List<Clear>();
    public int MaxComplete;
    public int Complete;

    // Start is called bfore the first frame update
    void Start()
    {
        
        ClearChecking.ClearChecked();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if (Complete == MaxComplete)
            Debug.Log("Å¬¸®¾î");
    }

}

namespace ClearCheck
{
    public class ClearChecking : MonoBehaviour
    {
        private static StageClear Clear_Mgr;
        
        public static void ClearChecked()
        {
            for (int i = 0; i < Clear_Mgr.ClearList.Count; i++)
            {
                if (Clear_Mgr.ClearList[i].ClearTile.gameObject.transform.rotation.z
                    == Clear_Mgr.ClearList[i].ClearRotation)
                    Clear_Mgr.Complete++;
                else
                {
                    if (Clear_Mgr.Complete != 0)
                        Clear_Mgr.Complete--;
                }
            }
        }

    }

}
