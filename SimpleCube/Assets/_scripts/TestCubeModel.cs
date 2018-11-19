using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using projectIntefaces;
using RubiksCubeSolverCS;
using System.Threading;

public class TestCubeModel : MonoBehaviour, ICubeController {

    public GameObject cube;
    public bool runTest = false;
    public bool runSimpleHighlightTest = false;
    public bool runHighlightTest = false;


    public RotatorsController rotatorsController;
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
        else
        if (runSimpleHighlightTest)
        {
            StartCoroutine(RunSimpleHighlightTest());
        }
        else
        if (runHighlightTest)
        {
            StartCoroutine(RunHighlightTest());
        }

        runSimpleHighlightTest = false;
        runHighlightTest       = false;
        runTest                = false;
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

    IEnumerator RunSimpleHighlightTest()
    {
        Move[] moves = { Move.L, Move.R, Move.U, Move.D, Move.F, Move.B, Move.LR, Move.RR, Move.UR, Move.DR, Move.FR, Move.BR };
        foreach (Move m in moves)
        {
            rotatorsController.OnHighlightMoveStart(m);
            yield return new WaitForSeconds(2);
            rotatorsController.OnHighlightMoveStop(m);
        }
    }

    IEnumerator RunHighlightTest()
    {
        RubicsCubeSolver solver = new RubicsCubeSolver();

        List<Move> moves = solver.ShuffleCube(25);
        moves.ForEach(m => DoMove(m));

        ICubeAlgorithm alg = new SimpleCubeAlgorithm();
        alg.DoMoves(moves);
        yield return new WaitForSeconds(5);

        while (!alg.IsSolved())
        {
            moves = alg.GetNextSolutionMoves();

            foreach (Move m in moves)
            {
                rotatorsController.OnHighlightMoveStart(m);
                yield return new WaitForSeconds(1);
                DoMove(m);
                rotatorsController.OnHighlightMoveStop(m);
                yield return new WaitForSeconds(0.5f);
            }

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
