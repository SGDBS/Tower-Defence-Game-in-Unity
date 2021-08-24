using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour {

    public Color hoverColor;
    public Renderer rend;
    public Color startColor;
    public Vector3 positionOffset;

    BuildManager buildManager;
    private GameObject turret;   //the turret we have built

    void Start() {
        buildManager = BuildManager.instance;
    }

    void OnMouseEnter() {
        if (buildManager.GetTurretToBuild() == null) {
            return;
        }
        rend.material.color = hoverColor;
    }

    void OnMouseExit() {
        rend.material.color = startColor;
    }

    void OnMouseDown() {
        if (buildManager.GetTurretToBuild() == null) {
            return;
        }       

        if(turret != null) {
            Debug.Log("We can not build here!!!!!!");
            return;
        }
        GameObject turretToBuild = BuildManager.instance.GetTurretToBuild();
        turret = (GameObject) Instantiate(turretToBuild, transform.position + positionOffset, transform.rotation);
    }
}
