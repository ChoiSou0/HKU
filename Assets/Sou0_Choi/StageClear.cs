using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    [SerializeField] private string CompleteSceneName;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        
    }

    public void Clear()
    {
        Complete = 0;

        for (int i = 0; i < ClearList.Count; i++)
        {
            if (ClearList[i].ClearTile.gameObject.transform.eulerAngles.z == ClearList[i].ClearRotation)
            {
                Complete++;
                
            }

        }
        Debug.Log(Complete);

        if (Complete == MaxComplete)
            UnityEngine.SceneManagement.SceneManager.LoadScene(CompleteSceneName);
    }
}
