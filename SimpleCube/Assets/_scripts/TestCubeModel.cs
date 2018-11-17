using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using projectIntefaces;
using RubiksCubeSolverCS;

public class TestCubeModel : MonoBehaviour, ICubeController {

    public GameObject cube;
    public bool runTest = false;

    private List<Move> moves = new List<Move>();  
    private ICubeModel cubeModel;

	// Use this for initialization
	void Start () {
        cubeModel = cube.GetComponent<ICubeModel>();
    }
	
	// Update is called once per frame
	void Update () {
        if (runTest)
        {
            StartCoroutine("RunTest");
        }

        runTest = false;
	}

    void RunTest()
    {
        RubicsCubeSolver solver = new RubicsCubeSolver();

        List<Move> moves = solver.ShuffleCube(100);
        moves.ForEach(m => DoMove(m));

        ICubeAlgorithm alg = new SimpleCubeAlgorithm();
        alg.DoMoves(moves);

        while (!alg.IsSolved())
        {
            moves = alg.GetNextSolutionMoves();
            moves.ForEach(m => DoMove(m));
            alg.DoMoves(moves);
        }
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
