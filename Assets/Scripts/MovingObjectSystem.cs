using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObjectSystem : MonoBehaviour
{

    [SerializeField] private MovingObject movingObject;
    [SerializeField] private Transform SpawnPos;
    [SerializeField] private Vector2 TimerMinMax;
    [SerializeField] private Vector2 SpeedMinMax;
    [SerializeField] private List<MovingObject> MovingObjectList;
    [SerializeField] private int MaxMovingObjectSize;
    float Timer,Speed;
    int Distance=0;
    bool wrongWay;
    private void OnEnable()
    {
        Timer = (float)Random.Range(TimerMinMax.x,TimerMinMax.y) / 10;
        Speed = (float)Random.Range(SpeedMinMax.x,SpeedMinMax.y) / 10;
        if (Random.Range(0, 2) == 1)
        {
            wrongWay = true;
            SpawnPos.localPosition =new Vector3(SpawnPos.localPosition.x, SpawnPos.localPosition.y, SpawnPos.localPosition.z*-1);
        }
    }
    void Start()
    {
        StartCoroutine(SpawnMovingObject());
    }

    private IEnumerator SpawnMovingObject()
    {
        if (MovingObjectList.Count < MaxMovingObjectSize)
        {
            MovingObject _movingObject = Instantiate(movingObject, SpawnPos.position, movingObject.transform.rotation);
            _movingObject.Speed = Speed;
            if(wrongWay) _movingObject.transform.Rotate(Vector3.up * 180);
            MovingObjectList.Add(_movingObject);
        }
        else
        {
            MovingObjectList[Distance].transform.position=SpawnPos.position;
            Distance++;
            if (Distance > MaxMovingObjectSize-1) Distance = 0;
        }
        yield return new WaitForSeconds(Timer);
        StartCoroutine(SpawnMovingObject());
    }
}
