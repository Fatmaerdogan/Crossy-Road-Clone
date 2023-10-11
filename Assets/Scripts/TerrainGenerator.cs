using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class TerrainGenerator : MonoBehaviour
{
    [SerializeField] private List<TerrainData> TerrainDataList = new List<TerrainData>();
    [SerializeField] private Transform TerrainHolder;
    List<GameObject> CurrentTerrainList = new List<GameObject>();

    [SerializeField] private int MaxTerrainCount;
    [SerializeField] private int MinDistanceFromPlayer;

    Vector3 currentPosition = new Vector3(0, 0, 0);
    private void Start()
    {
        Events.SpawnTerrain += PlayerDistanceControl;

        for(int i = 0; i < MaxTerrainCount; i++)SpawnTerrain(true);
        MaxTerrainCount = CurrentTerrainList.Count;
    }
    private void OnDestroy()
    {
        Events.SpawnTerrain -= PlayerDistanceControl;
    }
    void SpawnTerrain(bool isStart)
    {
 
        int whichTerrain = Random.Range(0, TerrainDataList.Count);
        int terrainInSuccession = Random.Range(1, TerrainDataList[whichTerrain].maxInSuccession);
        GameObject terrainPrefab = TerrainDataList[whichTerrain].terrainList[Random.Range(0, TerrainDataList[whichTerrain].terrainList.Count)];
        for (int i = 0; i < terrainInSuccession; i++)
        {
            GameObject terrain = Instantiate(terrainPrefab, new Vector3(currentPosition.x, terrainPrefab.transform.position.y,currentPosition.z), terrainPrefab.transform.rotation);
            terrain.transform.SetParent(TerrainHolder);
            CurrentTerrainList.Add(terrain);
            if (CurrentTerrainList.Count > MaxTerrainCount && !isStart)
            {
                Destroy(CurrentTerrainList[0]);
                CurrentTerrainList.RemoveAt(0);
            }
            currentPosition.z++;
        }


    }
    public void PlayerDistanceControl(Vector3 distance)
    {
        if (currentPosition.z - distance.z < MinDistanceFromPlayer) SpawnTerrain(false);
    }
}
