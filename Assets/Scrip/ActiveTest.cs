using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using static Walkable;

public class ActiveTest : MonoBehaviour
{
    public Walkable cubeWalkable;
    // Start is called before the first frame update

    void Start()
    {
        cubeWalkable = this.GetComponent<Walkable>(); // 获取cube物体的Walkable组件
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // 检测空格键是否被按下
        {
            cubeWalkable.possiblePaths[0].active = !cubeWalkable.possiblePaths[0].active;//cubewalkable的possiblePath属性的第[0]个元素的active修改
        }
           //{ cubeWalkable.active = !cubeWalkable.active; // 切换cube物体的active属性
    }
}

public class EveyPath
{
    public Walkable block;
    public int index;
}