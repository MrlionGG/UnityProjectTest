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
        cubeWalkable = this.GetComponent<Walkable>(); // ��ȡcube�����Walkable���
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // ���ո���Ƿ񱻰���
        {
            cubeWalkable.possiblePaths[0].active = !cubeWalkable.possiblePaths[0].active;//cubewalkable��possiblePath���Եĵ�[0]��Ԫ�ص�active�޸�
        }
           //{ cubeWalkable.active = !cubeWalkable.active; // �л�cube�����active����
    }
}

public class EveyPath
{
    public Walkable block;
    public int index;
}