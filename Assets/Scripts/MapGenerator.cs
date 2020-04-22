
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public GameObject[] saveZones;
    public GameObject[] roads;
    public GameObject LastPlaced;

    public void CreateNewMap()
    {
        int Random = UnityEngine.Random.Range(0, 100);
        if (Random <= 20)
        {
            Random = UnityEngine.Random.Range(0, saveZones.Length);
            GameObject obj = Instantiate(saveZones[Random]);
            obj.transform.position = LastPlaced.transform.position + new Vector3(0,0, 5);
            LastPlaced = obj;
        }
        else
        {
            Random = UnityEngine.Random.Range(0, roads.Length);
            GameObject obj = Instantiate(roads[Random]);
            obj.transform.position = LastPlaced.transform.position + new Vector3(0,0, 5);
            LastPlaced = obj;
        }
    }
}