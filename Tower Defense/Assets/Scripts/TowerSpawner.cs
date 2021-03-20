using UnityEngine;

public class TowerSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject towerBasePrefab;
    [SerializeField]
    private GameObject towerHeadPrefab;
    [SerializeField]
    private EnemySpawner enemySpawner;

    public void SpawnTower(Transform tileTransform)
    {
        Tile tile = tileTransform.GetComponent<Tile>();

        if (tile.IsBuildTower == true)
        {
            return;
        }

        tile.IsBuildTower = true;

        Instantiate(towerBasePrefab, tileTransform.position, Quaternion.identity);

        GameObject clone = Instantiate(towerHeadPrefab, tileTransform.position, Quaternion.identity);
        clone.GetComponent<TowerWeapon>().Setup(enemySpawner);
    }
}
