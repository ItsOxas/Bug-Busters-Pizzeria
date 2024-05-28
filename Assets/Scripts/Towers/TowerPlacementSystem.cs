using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;
using static UnityEngine.UI.Image;

public class TowerPlacementSystem : MonoBehaviour
{
    public Transform buyMenu;
    public Transform menuContent;
    public Transform placableGrid;
    public Transform placableGridHighlight;

    private bool placeMode = false;
    private Transform placeObject;

    public Transform sleeperPrefab;
    public Transform throwerPrefab;
    public Transform walkerPrefab;

    public List<Vector2> occupiedPositions = new List<Vector2>();

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && placeMode)
        {
            RaycastHit2D[] hit = Physics2D.RaycastAll(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            foreach(RaycastHit2D target in hit)
            {
                if(target.collider.gameObject.transform == placableGrid)
                {
                    TowerInstantiate();
                }
            }
        }   
    }

    public void BuyMenuToggle()
    {
        buyMenu.gameObject.active = !buyMenu.gameObject.active;
    }

    public void PlaceSleeper()
    {
        PlaceModeToggle();
        placeObject = sleeperPrefab;
    }

    public void PlaceThrower()
    {
        PlaceModeToggle();
        placeObject = throwerPrefab;
    }

    public void PlaceWalker()
    {
        PlaceModeToggle();
        placeObject = walkerPrefab;
    }

    public void PlaceModeToggle()
    {
        placeMode = !placeMode;
        buyMenu.gameObject.active = !buyMenu.gameObject.active;
        placableGridHighlight.gameObject.active = !placableGridHighlight.gameObject.active; 
    }

    public void TowerInstantiate()
    {
        bool isLegal = true;

        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 10;
        Vector2 worldPosition = Camera.main.ScreenToWorldPoint(mousePos);
        Vector3Int cellPosition = placableGrid.GetComponent<Tilemap>().WorldToCell(worldPosition);

        foreach(Vector2 pos in occupiedPositions)
        {
            print(Vector2.Distance(pos, (Vector2Int)cellPosition));
            if(Vector2.Distance(pos, (Vector2Int)cellPosition) < 4.5f)
            {
                isLegal = false;
            }
        }

        if (!isLegal) return;

        Instantiate(placeObject, cellPosition, Quaternion.identity);
        occupiedPositions.Add((Vector2Int)cellPosition);
        placeObject = null;

        PlaceModeToggle();
    }

}
