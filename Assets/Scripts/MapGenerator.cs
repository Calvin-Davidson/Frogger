using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public GameObject[] saveZonesDark;
    public GameObject[] saveZonesLight;
    private int Controler = 1;
    
    public GameObject[] roadsCarsFromLeft;
    public GameObject[] roadsCarsFromRight;
    
    public Transform LastPlaced;

    private string before = "savezone";

    public void CreateNewMap()
    {
        int Random = UnityEngine.Random.Range(0, 100);
        if (Random <= 50) // chance [50%] 
        {
            if (Controler == 1)
            {
                Random = UnityEngine.Random.Range(0, saveZonesDark.Length);
                GameObject obj = Instantiate(saveZonesDark[Random]);
                obj.transform.position = LastPlaced.transform.position + new Vector3(0, 0, 5);
                LastPlaced = obj.transform;
                if (before == "road")
                {
                    LastPlaced.transform.position = LastPlaced.transform.position + new Vector3(0, 0.7f, 0);
                }
                before = "savezone";
                Controler = 2;
                return;
            }
            if (Controler == 2)
            {
                Random = UnityEngine.Random.Range(0, saveZonesLight.Length);
                GameObject obj = Instantiate(saveZonesLight[Random]);
                obj.transform.position = LastPlaced.transform.position + new Vector3(0, 0, 5);
                LastPlaced = obj.transform;
                if (before == "road")
                {
                    LastPlaced.transform.position = LastPlaced.transform.position + new Vector3(0, 0.7f, 0);
                }

                before = "savezone";
                Controler = 1;
                return;
            }
        }
        else
        {
            Random = UnityEngine.Random.Range(0, roadsCarsFromLeft.Length);
            GameObject obj = Instantiate(roadsCarsFromLeft[Random]);
            obj.transform.position = LastPlaced.transform.position + new Vector3(0, 0, 5);
            LastPlaced = obj.transform;
            
            if (before == "savezone")
            {
                LastPlaced.transform.position = LastPlaced.transform.position + new Vector3(0, -0.7f, 0);
            }
            
            Random = UnityEngine.Random.Range(0, roadsCarsFromRight.Length);
            GameObject obj2 = Instantiate(roadsCarsFromRight[Random]);
            obj2.transform.position = LastPlaced.transform.position + new Vector3(0, 0, 5);
            LastPlaced = obj2.transform;
            
            before = "road";
        }
    }
}