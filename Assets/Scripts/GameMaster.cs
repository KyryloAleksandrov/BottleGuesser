using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    [SerializeField] Bottle[] bottlesToGuess;
    [SerializeField] MovableBottle[] movableBottles;
    [SerializeField] LayerMask movableBottleLayerMask;

    private MovableBottle selectedBottle;
    private List<Color> keyColors;
    private int counter;

    // Start is called before the first frame update
    void Start()
    {
        keyColors = new List<Color>();
        InitializeBottlesToGuess();
        InitializeBottlesToMove();

        GetCorrectCounters();
        Debug.Log(counter + " correct");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonUp(0))
        {
            if(TrySelectBottle())
            {
                return;
            }
        }
    }

    public void InitializeBottlesToGuess()
    {
        foreach(var bottle in bottlesToGuess)
        {
            Color randomColor = GetRandomColor();
            while(!IsUniqueColor(randomColor))
            {
                randomColor = GetRandomColor();
            }
            bottle.SetColor(randomColor);
            keyColors.Add(randomColor);
        }
    }

    public void InitializeBottlesToMove()
    {
        int count = 0;

        while(count < keyColors.Count)
        {
            int randomIndex = Random.Range(0, keyColors.Count);

            if(!movableBottles[randomIndex].GetIsSet())
            {
                movableBottles[randomIndex].SetColor(keyColors[count]);
                movableBottles[randomIndex].SetIsSet(true);
                count++;
            }
        }
    }

    public bool IsUniqueColor(Color color)
    {
        if(keyColors.Contains(color))
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public Color GetRandomColor()
    {
        Color[] colors = {Color.red, Color.blue, Color.green, Color.cyan, Color.magenta, Color.yellow, Color.white, Color.black};
        int colorIndex = Random.Range(0, 8);
        return colors[colorIndex];
    }

    public bool TrySelectBottle()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue, movableBottleLayerMask))
        {

            if(raycastHit.transform.TryGetComponent<MovableBottle>(out MovableBottle movableBottle))
            {
                if(movableBottle == selectedBottle)
                {
                    selectedBottle.HideSelected();
                    selectedBottle = null;
                    return true;
                }

                if(selectedBottle != null)
                {
                    SwapColors(selectedBottle, movableBottle);
                    GetCorrectCounters();
                    Debug.Log(counter + " correct");
                    selectedBottle = null;
                    return true;
                }

                selectedBottle = movableBottle;
                selectedBottle.ShowSelected();
                return true;
            }
        }
        return false;
    }

    public void SwapColors(MovableBottle A, MovableBottle B)
    {
        Color temp = A.GetColor();
        A.SetColor(B.GetColor());
        B.SetColor(temp);

        A.HideSelected();
        B.HideSelected();
    }

    public void GetCorrectCounters()
    {
        counter = 0;
        foreach(var bottle in bottlesToGuess)
        {
            if(bottle.CheckColor())
            {
                counter++;
            }
        }
    }
}
