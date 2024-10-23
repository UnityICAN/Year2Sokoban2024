using UnityEngine;

public class PlayerController : MonoBehaviour {
    [SerializeField] private BoardManager boardManager;
    private Vector2Int position;

    private void Start() {
        position = new Vector2Int(3, 3);
        transform.position = new Vector2(position.x, -position.y);
    }

    private void Update() {
        Vector2Int desiredPosition = position;

        if (Input.GetKeyDown(KeyCode.UpArrow))
            desiredPosition = new Vector2Int(position.x, position.y - 1);
        else if (Input.GetKeyDown(KeyCode.DownArrow))
            desiredPosition = new Vector2Int(position.x, position.y + 1);
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
            desiredPosition = new Vector2Int(position.x - 1, position.y);
        else if (Input.GetKeyDown(KeyCode.RightArrow))
            desiredPosition = new Vector2Int(position.x + 1, position.y);

        if (desiredPosition != position) {
            if (boardManager.board[desiredPosition.x, desiredPosition.y] == false) {
                position = desiredPosition;
                transform.position = new Vector2(position.x, -position.y);
            }
        }
    }
}
