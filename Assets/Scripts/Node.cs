using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour {

    [Header("System Initialization")]
    public Color hoverColor;
    public Renderer rend;
    public Color startColor;
    public Vector3 positionOffset;
    [Header("Optional")]
    public GameObject turret;   //the turret we have built

    BuildManager buildManager;

    void Start() {
        buildManager = BuildManager.instance;
    }

    public Vector3 getBuildPosition() {
        return transform.position + positionOffset;
    }

    void OnMouseEnter() {
        if (!buildManager.CanBuild) {
            return;
        }
        rend.material.color = hoverColor;
    }

    void OnMouseExit() {
        rend.material.color = startColor;
    }

    void OnMouseDown() {
        if (!buildManager.CanBuild) {
            return;
        }       

        if(turret != null) {
            Debug.Log("We can not build here!!!!!!");
            return;
        }

        buildManager.BuildTurretOn(this);
    }
}
