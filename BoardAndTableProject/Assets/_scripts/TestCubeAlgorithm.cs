using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace projectIntefaces
{
    class TestCubeAlgorithm : ICubeAlgorithm
    {
        private List<Move> moves;
        private int iDesc;
        private int finished;
        private List<string> descriptions;

        public TestCubeAlgorithm()
        {
            moves = new List<Move>();
            iDesc = -1;
            finished = -1;
            descriptions = new List<string>
            {
                "Solving cross",
                "Solving corners",
                "Solving Edges",
                "Solving OLL",
                "Solving PLL"
            };
        }

        public List<Move> GetNextSolutionMoves()
        {
            List<Move> m = new List<Move>();
            Random rnd = new Random();
            for(int i = 0; i < 7; i++)
            {
                m.Add((Move)(rnd.Next(0, 11)));
            }
            return m;
        }
        public void DoMoves(List<Move> _moves)
        {
            moves = _moves;
        }
        public bool IsSolved()
        {
            return (finished >= descriptions.Count);

        }
        public string GetNextSolutionMovesDescription()
        {
            finished++;
            if(++iDesc >= descriptions.Count)
            {
                iDesc = 0;
            }

            return descriptions[iDesc];
        }
    }
}
