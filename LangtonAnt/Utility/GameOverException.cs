using System;

namespace LangtonAnt.Utility
{
    public class GameOverException : Exception
    {
        public GameOverException(): base("Game Over")
        {

        }
    }
}