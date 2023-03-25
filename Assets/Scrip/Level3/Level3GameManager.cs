using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class Level3GameManager : MonoBehaviour
{
    public static Level3GameManager instance;

    public PlayerController player;
    public List<PathCondition3> pathConditions = new List<PathCondition3>();
    public List<Transform> pivots;
    
    public Transform[] objectsToHide;
    public Transform[] Leaves;

    private void Awake()
    {
        Debug.Log("Start");
        instance = this;
    }

    void Update()
    {

        foreach (PathCondition3 pc in pathConditions)
        {
            int count = 0;
            for (int i = 0; i < pc.conditions.Count; i++)
            {
                if (pc.conditions[i].conditionObject.eulerAngles == pc.conditions[i].eulerAngle)
                {
                    count++;
                }
            }
            foreach (SinglePath3 sp in pc.paths) {
                sp.block.possiblePaths[sp.index].active = (count == pc.conditions.Count);//设置路径Active
                Debug.Log(count);
            }
        }


        if (player.walking)
            return;
        

        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Debug.Log("KeyDown");
            int multiplier = Input.GetKey(KeyCode.RightArrow) ? 1 : -1;
            for (int i = 0; i < pivots.Count; i++) {
                pivots[i].DOComplete();
                pivots[i].DORotate(new Vector3(0, 90 * multiplier, 0), .6f, RotateMode.WorldAxisAdd).SetEase(Ease.OutBack);
            }
            
        }//旋转机关


        objectsToHide[0].gameObject.SetActive(pivots[1].eulerAngles.y > 190 && pivots[1].eulerAngles.y < 260);
        objectsToHide[1].gameObject.SetActive(pivots[1].eulerAngles.y >= 95 && pivots[1].eulerAngles.y < 180);


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
public class PathCondition3
{
    public string pathConditionName;
    public List<Conditions3> conditions;
    public List<SinglePath3> paths;
}
[System.Serializable]
public class Conditions3
{
    public Transform conditionObject;
    public Vector3 eulerAngle;

}
[System.Serializable]
public class SinglePath3
{
    public Walkable block;
    public int index;
}
