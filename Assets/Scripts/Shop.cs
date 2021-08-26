﻿using UnityEngine;

public class Shop : MonoBehaviour {

    public TurretBluePrint BasicTurret;
    public TurretBluePrint MissileLauncher;

    BuildManager buildManager;
    //using for set what to build
    void Start() {
        buildManager = BuildManager.instance;
    }

    public void selectMissileLauncher() {
        Debug.Log("Standard Turret Purchased");
        BuildManager.instance.selectTurretToBuild(MissileLauncher);
    }

    public void selectBasicTurret() {
        Debug.Log("Basic Turret Purchased");
        BuildManager.instance.selectTurretToBuild(BasicTurret);
    }
}
