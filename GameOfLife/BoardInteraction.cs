namespace GameOfLife
{
    public class BoardInteraction
    {
        // Board-Creation Variables
        private static int[, ] _boardDirections = {
            { 0, 1 },  { 1, 0 },
            { 0, -1 }, { -1, 0 },
            { 1, 1 },  { -1, -1 },
            { 1, -1 }, { -1, 1 }
        };
        private static int [, ] _boardNextGen;
        
        // Neighbor Counting
        private static int[, ] EnactGeneration(int[, ] boardCell)
        {
            int boardWidth = boardCell.GetLength(0), boardHeight = boardCell.GetLength(1);
            int[, ] boardNextGen = new int[boardWidth, boardHeight];
            _boardNextGen = boardNextGen;

            for (int i = 0; i < boardWidth; i++)
            {
                for (int j = 0; j < boardHeight; j++)
                {
                    int liveCell = 0;

                    // Counts The Live Cells In All Directions
                    for (int k = 0; k < 8; k++)
                    {
                        int x = i + _boardDirections[k, 0];
                        int y = j + _boardDirections[k, 1];

                        // Checks For Boundaries & Whether There Is An Alive Cell
                        if (x >= 0 && x < boardWidth && y >= 0 && y < boardHeight && boardCell[x, y] == 1)
                        {
                            liveCell++;
                        }
                    }
                    
                    if (boardCell[i, j] == 1 && (liveCell < 2 || liveCell > 3))
                    {
                        // Application Of Underpopulation & Overpopulation Rules
                        _boardNextGen[i, j] = 0;
                    } else if (boardCell[i, j] == 0 && liveCell == 3) {
                        // Reproduction Rule Of The Current Generation
                        _boardNextGen[i, j] = 1;
                    } else {
                        // Generation Survives
                        _boardNextGen[i, j] = boardCell[i, j];
                    }
                }
            }
            
            return boardNextGen;
        }
        
        // Visualise The Board
        private static void BoardDisplay(int[, ] boardCell)
        {
            // Retrive The Scale Of Width And Height
            int boardWidth = boardCell.GetLength(0), boardHeight = boardCell.GetLength(1);

            // Display Each Element
            for (int i = 0; i < boardWidth; i++)
            {
                for (int j = 0; j < boardHeight; j++)
                {
                    Console.Write(boardCell[i, j] == 1 ? "■ " : "□ ");
                }
                Console.WriteLine();
            }
        }
        
        // Navigation
        private static bool Navigation()
        {
            DisplayMessage("\n \nChoose The Action \n1 | Continue \n2 | Exit \n \n");
            string userInput = Console.ReadLine();
            
            while (true)
            {
                if (userInput.Equals("1"))
                {
                    Console.Clear();
                    return true;
                } else if (userInput.Equals("2")) {
                    Console.Clear();
                    return false;
                }
            }
        }
        
        // Display
        private static void DisplayMessage(string message)
        {
            for (int i = 0; i < message.Length; i++)
            {
                Console.Write(message[i].ToString().ToUpper());
                System.Threading.Thread.Sleep(20);
            }
        }
        
        // Run The Circuit
        public static void GameLoop()
        {
            int genCount = 0;
            
            int[, ] gameMatrix = {
                { 1, 0, 0, 0 },
                { 0, 0, 0, 1 },
                { 0, 1, 1, 0 },
                { 0, 0, 0, 1 }
            };

            while (true)
            {
                var nextGen = EnactGeneration(gameMatrix);
                BoardDisplay(nextGen);
                gameMatrix = nextGen;
                
                genCount++;
                DisplayMessage($"Current Generation: {genCount}");
                
                if (!Navigation()) break;
            }
        }
    }
}