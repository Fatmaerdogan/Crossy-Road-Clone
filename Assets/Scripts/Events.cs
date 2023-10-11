using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Events 
{
    public static Action<Vector3> SpawnTerrain;
    public static Action<int> ScoreChange;
    public static Action GameFinish;
}
