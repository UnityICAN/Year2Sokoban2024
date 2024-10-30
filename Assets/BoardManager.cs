using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour {
    [SerializeField] private GameObject wallTilePrefab;
    [SerializeField] private GameObject floorTilePrefab;
    [SerializeField] private GameObject boxTilePrefab;
    [SerializeField] private GameObject switchTilePrefab;
    [SerializeField] private GameObject boxAndSwitchTilePrefab;
    [SerializeField] private PlayerController playerController;

    [SerializeField] private LevelObject levelToLoad;

    public TileType[,] board { get; private set; }

    private void Start() {
        board = new TileType[10, 10];
        string[] levelLines = levelToLoad.content.Split('\n');

        for (int row = 0; row < 10; row++) {
            for (int col = 0; col < 10; col++) {
                switch (levelLines[row][col]) {
                    case 'F':
                        board[row, col] = TileType.Floor;
                        break;
                    case 'B':
                        board[row, col] = TileType.Box;
                        break;
                    case 'W':
                        board[row, col] = TileType.Wall;
                        break;
                    case 'S':
                        board[row, col] = TileType.Floor;
                        playerController.Init(new Vector2Int(col, row));
                        break;
                    case 'E':
                        board[row, col] = TileType.Switch;
                        break;
                }
            }
        }

        UpdateVisuals();
    }

    public void UpdateVisuals() {
        foreach (Transform childTransform in transform)
            Destroy(childTransform.gameObject);

        for (int row = 0; row < 10; row++) {
            for (int col = 0; col < 10; col++) {
                if (board[row, col] == TileType.Wall)
                    Instantiate(wallTilePrefab,
                        new Vector2(col, -row),
                        Quaternion.identity,
                        transform);
                else if (board[row, col] == TileType.Box)
                    Instantiate(boxTilePrefab,
                        new Vector2(col, -row),
                        Quaternion.identity,
                        transform);
                else if (board[row, col] == TileType.Switch)
                    Instantiate(switchTilePrefab,
                        new Vector2(col, -row),
                        Quaternion.identity,
                        transform);
                else if (board[row, col] == TileType.SwitchAndBox)
                    Instantiate(boxAndSwitchTilePrefab,
                        new Vector2(col, -row),
                        Quaternion.identity,
                        transform);
                else
                    Instantiate(floorTilePrefab,
                        new Vector2(col, -row),
                        Quaternion.identity,
                        transform);
            }
        }
    }
}
