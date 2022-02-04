using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CellScript : MonoBehaviour
{
    public bool isChecked = false;

    public int x;

    public int y;

    public void onPressed()
    {
        print("Cell pressed");

        GameScript game = GameObject.Find("UI").GetComponent<GameScript>();

        // GameScript game = GameObject.GetComponent<GameScript>();

        transform.Find("Button").gameObject.SetActive(false);

        if (game.currentTurn == CellType.Cross) {
            transform.Find("Cross").gameObject.SetActive(true);
        } else {
            transform.Find("Circle").gameObject.SetActive(true);
        }

        game.turnCompleted(x, y);
    }

    public void Reset() {
        print(transform.parent.name);

        transform.Find("Button").gameObject.SetActive(true);
        transform.Find("Cross").gameObject.SetActive(false);
        transform.Find("Circle").gameObject.SetActive(false);
    }
}
