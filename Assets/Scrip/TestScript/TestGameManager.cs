using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class TestGameManager : MonoBehaviour
{
    public static TestGameManager instance;

    public PlayerController player;
    public List<TPathCondition> pathConditions = new List<TPathCondition>();
    public List<Transform> pivots;
    
    public Transform[] objectsToHide;
    public Transform[] Leaves;

    public bool onGround=true;
    public GameObject DragObj;

    private void Awake()
    {
        Debug.Log("Start");
        instance = this;
    }
    void FixedUpdate()
    {
        
        foreach (TPathCondition pc in pathConditions)
        {
            int count = 0;
            for (int i = 0; i < pc.conditions.Count; i++)
            {
                if (Vector3.Distance(pc.conditions[i].conditionObject.position ,pc.conditions[i].positions)<1f)
                {
                    count++;
                }

            }
            foreach (TSinglePath sp in pc.paths) {
                sp.block.possiblePaths[sp.index].active = (count == pc.conditions.Count);//设置路径Active
                //Debug.Log(count);
            }
        }


        if (player.walking)
            return;
        

        /*if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            int multiplier = Input.GetKey(KeyCode.RightArrow) ? 1 : -1;
            for (int i = 0; i < pivots.Count; i++) {
                pivots[i].DOComplete();
                pivots[i].DORotate(new Vector3(0, 90 * multiplier, 0), .6f, RotateMode.WorldAxisAdd).SetEase(Ease.OutBack);
            }
            
        }//旋转机关*/

        if ( !Input.GetMouseButton(1)) {
            Debug.Log("onground");
            Sequence q = DOTween.Sequence();
            q.Append(DragObj.transform.DOMoveY(-6, 0.5f).SetEase(Ease.InOutElastic));
            DragObj.transform.DOComplete();
            //q.Append(DragObj.transform.DOShakeRotation(.5f,new Vector3(1,0,1),1,0,false));

        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
        }//重制关卡

    }

    public void GrowUp()
    {
        foreach (Transform leave in Leaves) {
            leave.gameObject.transform.DOScale(new Vector3(4.40949f, 6.424899f, 4.778414f), .6f).SetEase(Ease.OutBack);
        }
    }
}

[System.Serializable]
public class TPathCondition
{
    public string pathConditionName;
    public List<TConditions> conditions;
    public List<TSinglePath> paths;
}
[System.Serializable]
public class TConditions
{
    public Transform conditionObject;
    public Vector3 positions;

}
[System.Serializable]
public class TSinglePath
{
    public Walkable block;
    public int index;
}
