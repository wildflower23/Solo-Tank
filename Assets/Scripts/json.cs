using UnityEngine;

public class json : MonoBehaviour
{
    
    void Start()
    {
        Data data = new Data();
        data.name = "name1";
        data.SRno = 1;

        Data data2 = new Data();
        data2.name = "name2";
        data2.SRno = 2;

        string jsondata = JsonUtility.ToJson(data);
        string jsondata2 = JsonUtility.ToJson(data2);
        Debug.Log(jsondata);
        Debug.Log(jsondata2);
    }

    private class Data
    {
        public string name;
        public int SRno ;
    }
}
