using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    internal class Player
    {
        public string Username { get; private set; }
       
        private int score;
        public int Score
        {
            get { return score; }
            set 
            { 
                if(value > 0)
                score = value; 
            }
        }


        public List<char> GuessedLetters { get; } = new List<char>();

        public Player(string username)
        {
            this.Username = username;
        }

    }
}
