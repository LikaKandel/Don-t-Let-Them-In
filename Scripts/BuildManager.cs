using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    private TurretBlueprint turretToBuild;
    private Node selectedNode;
    public NodeUI nodeUI;

    public bool CanBuild { get { return turretToBuild != null; } }
    public bool HasMoney { get { return PlayerStats.Money >= turretToBuild.cost; } }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one Build Manager");
            return;
        }
        instance = this;
    }
    
    public void SelectNode(Node node)
    {
        if (selectedNode == node)
        {
            DeselectNode();
            return;
        }

        selectedNode = node;
        turretToBuild = null;
        print("node is selected");
        nodeUI.SetTarget(node);
    }
    
    public void BuildTurretOn(Node node)
    {
        if (PlayerStats.Money < turretToBuild.cost)
        {
            Debug.Log("not enough money");
            return;
        }
        PlayerStats.Money -= turretToBuild.cost;

        GameObject turret = (GameObject)Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
        node.turret = turret;
    }
    public void DeselectNode()
    {
        selectedNode = null;
        nodeUI.Hide();
    }
    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        print("turret selected to build");
        turretToBuild = turret;
        DeselectNode();
    }
    public TurretBlueprint GetTurretToBuild()
    {
        return turretToBuild;
    }
}
