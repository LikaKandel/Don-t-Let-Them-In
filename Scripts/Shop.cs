using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    BuildManager buildmanager;
    public TurretBlueprint standardTurret;
    public TurretBlueprint missileLaucher;
    public TurretBlueprint laserBeamer;
    private void Start()
    {
        buildmanager = BuildManager.instance;
    }
    public void SelectStandardTurret()
    {
        buildmanager.SelectTurretToBuild(standardTurret);
    }

    public void SelectMissileLaucher()
    {
        buildmanager.SelectTurretToBuild(missileLaucher);
    }
    public void SelectLaserBeamer()
    {
        buildmanager.SelectTurretToBuild(laserBeamer);
    }
}
