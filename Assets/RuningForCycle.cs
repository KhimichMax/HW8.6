using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuningForCycle : MonoBehaviour
{
    [SerializeField] private Transform _startGameObj;
    [SerializeField] private Transform _cubeGameObj;
    [SerializeField] private Transform _firstGameObj;
    [SerializeField] private Transform _secondGameObj;
    [SerializeField] private Transform _thirdGameObj;
    private List<Vector3> allPositionVec = new List<Vector3>();
    private Vector3 _targetCube;
    private int _countArrVecItem = 0;
    private bool flag;

    private void AddAllPositionVec()
    {
        allPositionVec.Add(_startGameObj.position);
        allPositionVec.Add(_firstGameObj.position);
        allPositionVec.Add(_secondGameObj.position);
        allPositionVec.Add(_thirdGameObj.position);
    }

    private void GoingCyclePositionVec()
    {
        _cubeGameObj.position = Vector3.MoveTowards(_cubeGameObj.position, _targetCube, Time.deltaTime);
        if (!flag)
        {
            for (int i = 0; i < allPositionVec.Count; i++)
            {
                if (_cubeGameObj.position == allPositionVec[i])
                {
                    if (allPositionVec.Count - 1 > _countArrVecItem)
                    {
                        _targetCube = allPositionVec[i + 1];
                        _cubeGameObj.LookAt(_targetCube);
                        _countArrVecItem += 1;
                        
                    }else if (allPositionVec.Count - 1 == _countArrVecItem)
                    {
                        flag = true;
                        _countArrVecItem = 0;
                    }       
                }
            }
        }else if (flag)
        {
            for (int i = allPositionVec.Count - 1; i > 0; i--)
            {
                if (_cubeGameObj.position == allPositionVec[i])
                {
                    if (i > _countArrVecItem)
                    {
                        _targetCube = allPositionVec[i - 1];
                        _cubeGameObj.LookAt(_targetCube);
                        if (i == _countArrVecItem + 1)
                        {
                            flag = false;
                        } 
                    }      
                }
            }
        }
    }
    
    void Start()
    {
        AddAllPositionVec();
        _targetCube = _startGameObj.position;
        _cubeGameObj.LookAt(_targetCube);
    }

    
    void Update()
    {
        GoingCyclePositionVec();
    }
}
