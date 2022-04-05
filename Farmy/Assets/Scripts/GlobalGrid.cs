using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalGrid{

    private int width;
    private int height;
    private float cellSize;
    private int[,] gridArray;


    public GlobalGrid(int width, int height, float cellSize){
        this.width = width;
        this.height = height;
        this.cellSize = cellSize;

        gridArray = new int[width,height];

        for(int x = 0 ;x< this.width;x++){
            for(int y = 0 ;y< this.height;y++){
                Debug.DrawLine(GetWorldPostition(x,y),GetWorldPostition(x,y+1),Color.white, 100f);
                Debug.DrawLine(GetWorldPostition(x,y),GetWorldPostition(x+1,y),Color.white, 100f);
                gridArray[x,y]=0;
            }
        }

        Debug.DrawLine(GetWorldPostition(0,height),GetWorldPostition(width,height),Color.white, 100f);
        Debug.DrawLine(GetWorldPostition(width,0),GetWorldPostition(width,height),Color.white, 100f);

        Debug.Log("Grid created!");
    }

    private Vector3 GetWorldPostition(int x, int y){
        return new Vector3(x,0,y)*cellSize;
    }

    public Vector3 AdaptToGrid(Vector3 worldPosition){

        //Comprobar si la posicion está dentro de la rejilla
        if(worldPosition.x>= 0 && worldPosition.z>=0 && worldPosition.x < this.width * cellSize && worldPosition.z < this.height*cellSize){
            //Calcular el valor de la rejilla
            int x,y;
            GetXY(worldPosition,out x , out y);
            return GetWorldPostition(x, y);
        }
        return Vector3.zero;
    }

    public void GetXY(Vector3 worldPosition, out int x, out int y){
        x = Mathf.FloorToInt(worldPosition.x / cellSize);
        y = Mathf.FloorToInt(worldPosition.z / cellSize);
    }

    public void SetGridArrayValue(Vector3 worldPosition, int value){
        int x,y;
        GetXY(worldPosition,out x , out y);

        gridArray[x,y] = value;
    }

    public int GetGridArrayValue(Vector3 worldPosition){
        int x,y;
        GetXY(worldPosition,out x , out y);

        return gridArray[x,y];
    }

}
