using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GameParallaxEffect : MonoBehaviour
{

    Vector3 _startingPos;
    float _lengthOfSprite;
    [SerializeField] private float AmountOfParallax;
    // [SerializeField] private int repeatDistance = 5;
    [SerializeField] private bool infinitHorizontal;
    [SerializeField] private bool infinitVertical;
    public GridLayout gridLayout;
    public Camera mainCam;
    private Vector3 lastCameraPos;
    private Vector3 initGridLayoutPos;

    // Start is called before the first frame update
    void Start()
    {
        _startingPos = transform.position;
        lastCameraPos = mainCam.transform.position;
        if(gameObject.CompareTag("Grid")) initGridLayoutPos = gridLayout.transform.position;
        getSpriteLength();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (infinitHorizontal)
        {
            Vector3 pos = mainCam.transform.position;
            float temp = pos.x * (1 - AmountOfParallax);
            float dist = pos.x * AmountOfParallax;

            Vector3 newPos = new Vector3(_startingPos.x + dist, transform.position.y, transform.position.z);
            transform.position = newPos;

            if (temp > _startingPos.x + (_lengthOfSprite / 2))
            {
                _startingPos.x += _lengthOfSprite;
            }
            else if (temp < _startingPos.x - (_lengthOfSprite / 2))
            {
                _startingPos.x -= _lengthOfSprite;
            }
        }

        if (infinitVertical)
        {
            Vector3 pos = mainCam.transform.position;
            float temp = pos.y * (1 - AmountOfParallax);
            float dist = pos.y * AmountOfParallax;

            Vector3 newPos = new Vector3(transform.position.x, _startingPos.y + dist, transform.position.z);
            transform.position = newPos;

            if (temp > _startingPos.y + (_lengthOfSprite / 2))
            {
                _startingPos.y += _lengthOfSprite;
            }
            else if (temp < _startingPos.y - (_lengthOfSprite / 2))
            {
                _startingPos.y -= _lengthOfSprite;
            }
        }
        
        //if (gameObject.CompareTag("Sprite"))
        //{
        //    Vector3 pos = MainCam.transform.position;
        //    float temp = pos.x * (1 - AmountOfParallax);
        //    float dist = pos.x * AmountOfParallax;

        //    Vector3 newPos = new Vector3(_startingPos + dist, transform.position.y, transform.position.z);
        //    transform.position = newPos;

        //    if (temp > _startingPos + (_lengthOfSprite / 2))
        //    {
        //        _startingPos += _lengthOfSprite;
        //    }
        //    else if (temp < _startingPos - (_lengthOfSprite / 2))
        //    {
        //        _startingPos -= _lengthOfSprite;
        //    }
        //}
        //else if (gameObject.CompareTag("Grid"))
        //{
        //    Vector3 deltaMovement = MainCam.transform.position - lastCameraPos;
        //    gridLayout.transform.position += deltaMovement * AmountOfParallax;

        //    Vector3 diff = gridLayout.transform.position - initGridLayoutPos;
        //    Tilemap[] _tilemap = gridLayout.GetComponentsInChildren<Tilemap>();
        //    if (diff.x > gridLayout.cellSize.x * repeatDistance)
        //    {
        //        int direction = 1;
        //        gridLayout.transform.position -= new Vector3(gridLayout.cellSize.x * direction * repeatDistance, 0f, 0f);

        //        Repite los Tilemaps en el grid
        //        foreach (var tilemap in gridLayout.GetComponentsInChildren<Tilemap>())
        //        {
        //            Vector3Int offset = new Vector3Int(repeatDistance * direction, 0, 0);
        //            BoundsInt bounds = tilemap.cellBounds;
        //            TileBase[] tiles = tilemap.GetTilesBlock(bounds);

        //            for (int x = bounds.x; x < bounds.x + bounds.size.x; x++)
        //            {
        //                for (int y = bounds.y; y < bounds.y + bounds.size.y; y++)
        //                {
        //                    TileBase tile = tilemap.GetTile(new Vector3Int(x, y, bounds.z));
        //                    tilemap.SetTile(new Vector3Int(x + offset.x, y, bounds.z), tile);
        //                }
        //            }
        //        }
        //    }
        //    else if (diff.x < gridLayout.cellSize.x * repeatDistance)
        //    {

        //    }
        //    lastCameraPos = MainCam.transform.position;
        //}

    }

    void getSpriteLength()
    {
        if (GetComponent<SpriteRenderer>())
        {
            _lengthOfSprite = GetComponent<SpriteRenderer>().bounds.size.x;
        }else if (gameObject.CompareTag("Grid"))
        {
            Tilemap tilemap = GetComponentInChildren<Tilemap>();
            _lengthOfSprite = tilemap.size.x;
        }
    }
}
