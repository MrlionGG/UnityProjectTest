//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using DG.Tweening;
//using UnityEngine.SceneManagement;

//public class GameManager : MonoBehaviour
//{
//    public static GameManager instance;

//    public PlayerController player;
//    public List<PathCondition> pathConditions = new List<PathCondition>();
//    //public List<Transform> pivots;

//    // Start is called before the first frame update
//    private void Awake()
//    {
//        instance = this;
//    }
//    void Start()
//    {
        
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        foreach (PathCondition pc in pathConditions)
//        {
//            int count = 0;
//            for (int i = 0; i < pc.conditions.Count; i++)
//            {
//                if (pc.conditions[i].conditionObject.eulerAngles == pc.conditions[i].eulerAngle)
//                {
//                    count++;
//                }
//            }
//            foreach (SinglePath sp in pc.paths)
//                sp.block.possiblePaths[sp.index].active = (count == pc.conditions.Count);//ÉèÖÃÂ·¾¶Active

//        }
//    }
//}
//[System.Serializable]
//public class PathCondition
//{
//    public string pathConditionName;
//    public List<Level1Condition> conditions;
//    public List<SinglePath> paths;
//}
//[System.Serializable]
//public class SinglePath
//{
//    public Walkable block;
//    public int index;
//}
//[System.Serializable]
//public class Level1Condition
//{
//    public Transform conditionObject;
//    public Vector3 eulerAngle;
//}