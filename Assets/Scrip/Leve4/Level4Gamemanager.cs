using System.Collections;
using System.Threading;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class Level4Gamemanager : MonoBehaviour
{
    public static Level4Gamemanager instance;

    public GameObject dragObject;
    public string dragTag;

    public PlayerController player;
    public List<PathCondition4> pathConditions = new List<PathCondition4>();
    public List<GameObject> FallenPath = new List<GameObject>();

    public List<GameObject> StarMoveObj = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        Sequence q = DOTween.Sequence();
        q.Append(Camera.main.transform.DOShakePosition(5f, new Vector3(.5f, .5f, 0), 10, 90, false, true));
        q.Append(StarMoveObj[0].transform.DOBlendableLocalMoveBy(new Vector3(0, -44.75f, 0), 1.2f)).SetEase(Ease.OutQuint);
        q.Append(Camera.main.transform.DOShakePosition(1, new Vector3(.5f, .5f, 0), 10, 90, false, true));
    }


    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Mouse1)) 
        {
            RaycastHit hit; 
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 1000)) 
            { 
                if (hit.collider.CompareTag(dragTag) && !FallenPath.Contains(hit.collider.gameObject)) 
                { 
                    FallenPath.Add(hit.collider.gameObject);
                    MoveDown(hit.collider.gameObject); 
                }
            }
        }//检测击中物体并执行动画*/

        foreach (PathCondition4 pc in pathConditions)
        {
            int count = 0;
            for (int i = 0; i < pc.conditions.Count; i++)
            {
                if (FallenPath.Contains(pc.conditions[i].conditionObject))
                {
                    count++;
                }

            }
            foreach (SinglePath4 sp in pc.paths)
            {
                sp.block.possiblePaths[sp.index].active = (count == pc.conditions.Count);//设置路径Active
                //Debug.Log(count);
            }
        }
    }
    public void MoveDown(GameObject obj) {
        Sequence q = DOTween.Sequence();
        q.Append(obj.transform.DOBlendableLocalMoveBy(new Vector3(0, -44.75f, 0), 1.2f)).SetEase(Ease.OutQuint);
        q.Append(Camera.main.transform.DOShakePosition(1, new Vector3(.5f, .5f, 0), 10, 90, false, true));
        
    }

    void TestFunc()
    {
        Debug.Log( "wait" );
    }
}

[System.Serializable]
public class PathCondition4
{
    public string pathConditionName;
    public List<Conditions4> conditions;
    public List<SinglePath4> paths;
}
[System.Serializable]
public class SinglePath4
{
    public Walkable block;
    public int index;
}
[System.Serializable]

public class Conditions4
{
    public GameObject conditionObject;
}