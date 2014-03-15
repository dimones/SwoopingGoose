using UnityEngine;
using System.Collections;

public class GenerateLevel : MonoBehaviour {
    public GameObject _block;
    System.Random _rand = new System.Random();
    public void Start()
    {
        //Generate();
    }
	public bool Generate()
    {
        print(GetPos().ToString());
        return true;
    }
    private Vector2 GetPos()
    {
        int random = _rand.Next(4, 9);
        float _fl1 = (float)_rand.NextDouble()*random;
        float _fl2 = 10-_fl1-_rand.Next(1,3);
        return new Vector2(1f,_fl1);
    }
}
