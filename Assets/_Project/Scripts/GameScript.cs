using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum CellType {
    Empty,
    Cross,
    Circle,
    Draw
}
public class GameScript : MonoBehaviour
{
    public CellType currentTurn = CellType.Cross;

    private CellType[,] board = new CellType[3, 3];

    public void TryPressed() {
        Debug.Log("Try pressed");
    }

    public void Start()
    {
        TryPressed();

        resetBoard();
    }

    public void turnCompleted(int x, int y) {
        board[x,y] = currentTurn;

        if (currentTurn == CellType.Cross) {
            currentTurn = CellType.Circle;
        } else {
            currentTurn = CellType.Cross;
        }

        CellType winner = maybeCurrentWinner();

        Debug.Log("Winner is " + winner.ToString());

        if (winner != CellType.Empty) {
            resetBoard();

            if (winner == CellType.Draw) {
                Debug.Log("Draw");
            } else {
                Debug.Log("Winner is " + winner.ToString());

                GameObject.Find("Winner").transform.Find("CrossWinner").gameObject.SetActive(winner == CellType.Cross);
                GameObject.Find("Winner").transform.Find("CircleWinner").gameObject.SetActive(winner == CellType.Circle);
            }
        }
    }

    private CellType maybeCurrentWinner() {
        // calculate TicTacToe winner
        if (board[0,0] == CellType.Cross && board[0, 1] == CellType.Cross && board[0, 2] == CellType.Cross) {
            return CellType.Cross;
        } else if (board[1,0] == CellType.Cross && board[1, 1] == CellType.Cross && board[1, 2] == CellType.Cross) {
            return CellType.Cross;
        } else if (board[2,0] == CellType.Cross && board[2, 1] == CellType.Cross && board[2, 2] == CellType.Cross) {
            return CellType.Cross;
        } else if (board[0,0] == CellType.Cross && board[1, 0] == CellType.Cross && board[2, 0] == CellType.Cross) {
            return CellType.Cross;
        } else if (board[0,1] == CellType.Cross && board[1, 1] == CellType.Cross && board[2, 1] == CellType.Cross) {
            return CellType.Cross;
        } else if (board[0,2] == CellType.Cross && board[1, 2] == CellType.Cross && board[2, 2] == CellType.Cross) {
            return CellType.Cross;
        } else if (board[0,0] == CellType.Cross && board[1, 1] == CellType.Cross && board[2, 2] == CellType.Cross) {
            return CellType.Cross;
        } else if (board[0,2] == CellType.Cross && board[1, 1] == CellType.Cross && board[2, 0] == CellType.Cross) {
            return CellType.Cross;
        } else if (board[0,0] == CellType.Circle && board[0, 1] == CellType.Circle && board[0, 2] == CellType.Circle) {
            return CellType.Circle;
        } else if (board[1,0] == CellType.Circle && board[1, 1] == CellType.Circle && board[1, 2] == CellType.Circle) {
            return CellType.Circle;
        } else if (board[2,0] == CellType.Circle && board[2, 1] == CellType.Circle && board[2, 2] == CellType.Circle) {
            return CellType.Circle;
        } else if (board[0,0] == CellType.Circle && board[1, 0] == CellType.Circle && board[2, 0] == CellType.Circle) {
            return CellType.Circle;
        } else if (board[0,1] == CellType.Circle && board[1, 1] == CellType.Circle && board[2, 1] == CellType.Circle) {
            return CellType.Circle;
        } else if (board[0,2] == CellType.Circle && board[1, 2] == CellType.Circle && board[2, 2] == CellType.Circle) {
            return CellType.Circle;
        } else if (board[0,0] == CellType.Circle && board[1, 1] == CellType.Circle && board[2, 2] == CellType.Circle) {
            return CellType.Circle;
        } else if (board[0,2] == CellType.Circle && board[1, 1] == CellType.Circle && board[2, 0] == CellType.Circle) {
            return CellType.Circle;
        } else {
            if (board[0,0] != CellType.Empty && board[0,1] != CellType.Empty && board[0,2] != CellType.Empty &&
                board[1,0] != CellType.Empty && board[1,1] != CellType.Empty && board[1,2] != CellType.Empty &&
                board[2,0] != CellType.Empty && board[2,1] != CellType.Empty && board[2,2] != CellType.Empty) {
                return CellType.Draw;
            } else {
                return CellType.Empty;
            }
        }
    }

    public void resetBoard() {
        for (int i = 0; i < 3; i++) {
            for (int j = 0; j < 3; j++) {
                board[i, j] = CellType.Empty;
            }
        }

        foreach (CellScript obj in GameObject.FindObjectsOfType<CellScript>()) {
            obj.Reset();
        }
    }
}
