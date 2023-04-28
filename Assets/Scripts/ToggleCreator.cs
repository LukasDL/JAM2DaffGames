using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleCreator : MonoBehaviour
{
    public int sizeLine = 2;
    public int sizeCount = 7;
    public GameObject _prefabLine;
    public GameObject _prefabToggle;
    public int[,] patch;

    private void Start()
    {
        patch = new int[sizeLine,sizeCount];
        for(int i = 0; i < sizeLine; i++)
        {
            GameObject line = Instantiate(_prefabLine, transform.position, Quaternion.identity);
            line.transform.SetParent(transform, false);
            AddToggleInLine addInLine = line.GetComponent<AddToggleInLine>(); 
            for (int j = 0; j < sizeCount; j++)
            {
                GameObject toggle = Instantiate(_prefabToggle, transform.position, Quaternion.identity);
                toggle.GetComponent<ToggleItem>().SetVector(i,j);
                patch[i, j] = 0;
                addInLine.AddToggle(toggle); 
            }
        }
    }
    public void ChangePatch(int a, int b)
    {
        patch[a, b] = 1;
    }

}
