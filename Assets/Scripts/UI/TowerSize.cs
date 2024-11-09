using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TowerSize : MonoBehaviour
{
    [SerializeField] private Tower tower;
    [SerializeField] private TMP_Text towerSizeText;
    private void OnEnable()
    {
        tower.OnTowerSizeUpdate += Tower_OnTowerSizeUpdate;
    }

    private void Tower_OnTowerSizeUpdate(int size)
    {
        towerSizeText.text = size.ToString();
    }

    private void OnDisable()
    {
        tower.OnTowerSizeUpdate -= Tower_OnTowerSizeUpdate;
    }
}
