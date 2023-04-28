using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateGrid : MonoBehaviour
{
    public GameObject _prefabItem;
    public int _sizeX = 3;
    public int _sizeY = 3;
    public RectTransform canvasRectTransform;

    private void Start()
    {
        CreatePlane();
    }
    private void CreatePlane()
    {
        Vector2 size = canvasRectTransform.sizeDelta;
        print(size.x + " " + size.y);
        float oneItemX = size.x / _sizeX;
        float oneItemY = size.y / _sizeY;

        for(int i = 0; i<_sizeX; i++)
        {
            for(int j = 0; j < _sizeY; j++)
            {
                float x = oneItemX * i + oneItemX;
                float y = oneItemY * j + oneItemY;
                print("x " + x);
                print("y " + y);
                Vector3 pos = new Vector3(x, y, 0);
                GameObject obj = Instantiate(_prefabItem, pos, Quaternion.identity);
               // obj.transform.parent = this.transform;
            }
        }
    }
}
