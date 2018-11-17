using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using projectIntefaces;

public class SimpleCubeController : MonoBehaviour, ICubeController {

    private List<Move> moves = new List<Move>();
    public GameObject cube;
    private ICubeModel cubeModel;
	// Use this for initialization
	void Start () {
        cubeModel = cube.GetComponent<ICubeModel>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void DoMove(Move m)
    {
        moves.Add(m);
        cubeModel.AnimateMove(m);
    }

    public List<Move> GetMoves()
    {
        return moves;
    }
}
