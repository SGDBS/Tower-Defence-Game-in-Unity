using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour {

    public Color hoverColor;
    public Renderer rend;
    public Color startColor;
    public Vector3 positionOffset;

    BuiltManager builtManager;
    private GameObject turret;

    void Start() {
        builtManager = BuiltManager.instance;
    }

    void OnMouseEnter() {
        //if (EventSystem.current.IsPointerOverGameObject()) {
        //    return;
        //}

        if (builtManager.GetTurretToBuild() == null) {
            return;
        }
        rend.material.color = hoverColor;
    }

    void OnMouseDown() {

        //if (EventSystem.current.IsPointerOverGameObject()) {
        //    return;
        //}

        if (builtManager.GetTurretToBuild() == null) {
            return;
        }       

        if(turret != null) {
            Debug.Log("We can not build here!!!!!!");
            return;
        }
        GameObject turretToBuilt = BuiltManager.instance.GetTurretToBuilt();
        turret = (GameObject) Instantiate(turretToBuilt, transform.position + positionOffset, transform.rotation);
    }

    void OnMouseExit() {
        rend.material.color = startColor;
    }
}
