using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level2GameManager : MonoBehaviour
{
    public static Level2GameManager instance;
    public PlayerController player;
    public List<PathCondition2> pathConditions = new List<PathCondition2>();
    public List<Transform> pivots;
    public Transform[] objectsToHide;

    private bool PressedUp = false;
    public Walkable StartCube;

    // Start is called before the first frame update
    void Start()
    {
        StartCube = GameObject.Find("Cube").GetComponent<Walkable>();
        Debug.Log("Start");
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        foreach (PathCondition2 pc in pathConditions)
        {
            int count = 0;
            for (int i = 0; i < pc.conditions.Count; i++)
            {
                if (pc.conditions[i].conditionObject.eulerAngles == pc.conditions[i].eulerAngle) 
                {
                    count++;
                }
                
            }
            if (PressedUp == false) {
                count++;
               // Debug.Log("test11");
            }
            foreach (SinglePath2 sp in pc.paths) { 
                sp.block.possiblePaths[sp.index].active = (count == pc.conditions.Count);//设置路径Active
                if (PressedUp == false)
                    StartCube.possiblePaths[0].active = false;

            }
        }
        if (player.walking)
            return;
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            //pivots[0].DOComplete();
            if (!PressedUp)
            {
                pivots[0].transform.DOBlendableMoveBy(new Vector3(0, 7.5f, 0), .6f).SetEase(Ease.OutBack);
                PressedUp = true;
            }

        }//上下机关
            if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            //pivots[0].DOComplete();
            if (PressedUp)
            {
                pivots[0].transform.DOBlendableMoveBy(new Vector3(0, -7.5f, 0), .6f).SetEase(Ease.OutBack);
                PressedUp = false;
            }

        }
        foreach (Transform t in objectsToHide)
        {
            t.gameObject.SetActive(pivots[1].eulerAngles.y > 20 && pivots[1].eulerAngles.y < 300);
        }//隐藏单面贴图

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
        }//重制关卡

    }
    public void RotateRightPivot2()
    {
        pivots[1].DOComplete();
        pivots[1].DORotate(new Vector3(0, 0, 90), 1f).SetEase(Ease.OutBack);
    }
}
[System.Serializable]

public class PathCondition2
{
    public string pathConditionName;
    public List<Conditions2> conditions;
    public List<SinglePath2> paths;
}
[System.Serializable]

public class SinglePath2
{
    public Walkable block;
    public int index;
}
[System.Serializable]

public class Conditions2
{
    public Transform conditionObject;
    public Vector3 eulerAngle;
}