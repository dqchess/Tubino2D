using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class UILevelSelector : MonoBehaviour
{

    public GameObject prefabItem;
    public Transform container;

    private void Start()
    {
        for (int i = 0; i < Constants.numLevel; i++)
        {
            ItemLevelSelector item = GameObject.Instantiate(prefabItem).GetComponent<ItemLevelSelector>();
            item.gameObject.transform.SetParent(container, false);
            item.Initialize(i);


        }
    }
    public void OnClick(int level)
    {
       
    }
}
