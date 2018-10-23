using System;
using System.Linq;

namespace DangerousFloor
{
    class DangerousFloor
    {
        static char[][] board;
        static void Main(string[] args)
        {
            board = new char[8][];
            FillMatrix();
            string command = "";
            int code = 0;
            while ((command = Console.ReadLine()) != "END")
            {
                char figure = command[0];
                int initialRow = int.Parse(command[1].ToString());
                int initialCol = int.Parse(command[2].ToString());
                int targetRow = int.Parse(command[4].ToString());
                int targetCol = int.Parse(command[5].ToString());

                if (figure == 'K')
                {
                    code = MoveKing(initialRow, initialCol, targetRow, targetCol);
                }
                else if (figure == 'R')
                {
                    code = MoveRook(initialRow, initialCol, targetRow, targetCol);
                }
                else if (figure == 'B')
                {
                    code = MoveBishop(initialRow, initialCol, targetRow, targetCol);
                }
                else if (figure == 'Q')
                {
                    code = MoveQueen(initialRow, initialCol, targetRow, targetCol);
                }
                else if (figure == 'P')
                {
                    code = MovePawn(initialRow, initialCol, targetRow, targetCol);
                }

                if (code == 1)
                {
                    Console.WriteLine("There is no such a piece!");
                }
                else if (code == 2)
                {
                    Console.WriteLine("Invalid move!");
                }
                else if (code == 3)
                {
                    Console.WriteLine("Move go out of board!");
                }
            }
        }

        private static int MoveKing(int initialRow, int initialCol, int targetRow, int targetCol)
        {
            int code = 0;
            if (board[initialRow][initialCol] == 'K')
            {
                bool canMoveUpDown = initialRow == targetRow - 1 || initialRow == targetRow + 1 || initialRow == targetRow;
                bool canMoveRightLeft = initialCol == targetCol - 1 || initialCol == targetCol + 1 || initialCol == targetCol;

                if (canMoveRightLeft && canMoveUpDown)
                {
                    if (IsInside(targetRow, targetCol))
                    {
                        board[initialRow][initialCol] = 'x';
                        board[targetRow][targetCol] = 'K';
                    }
                    else
                    {
                        return 3;
                    }
                }
                else
                {
                    return 2;
                }
            }
            else
            {
                code = 1;
            }

            return code;
        }

        private static int MoveRook(int initialRow, int initialCol, int targetRow, int targetCol)
        {
            int code = 0;
            if (board[initialRow][initialCol] == 'R')
            {
                if (initialRow == targetRow || initialCol == targetCol)
                {
                    if (IsInside(targetRow, targetCol))
                    {
                        board[initialRow][initialCol] = 'x';
                        board[targetRow][targetCol] = 'R';
                    }
                    else
                    {
                        return 3;
                    }
                }
                else
                {
                    return 2;
                }
            }
            else
            {
                code = 1;
            }

            return code;
        }

        private static int MoveBishop(int initialRow, int initialCol, int targetRow, int targetCol)
        {
            int code = 0;
            if (board[initialRow][initialCol] == 'B')
            {
                bool canMovePrimaryDiagonal = initialRow + initialCol == targetRow + targetCol;
                bool canMoveSecondaryDiagonal = targetRow - initialRow == targetCol - initialCol;
                if (canMovePrimaryDiagonal || canMoveSecondaryDiagonal)
                {
                    if (IsInside(targetRow, targetCol))
                    {
                        board[initialRow][initialCol] = 'x';
                        board[targetRow][targetCol] = 'B';
                    }
                    else
                    {
                        return 3;
                    }
                }
                else
                {
                    return 2;
                }
            }
            else
            {
                code = 1;
            }

            return code;
        }

        private static int MoveQueen(int initialRow, int initialCol, int targetRow, int targetCol)
        {
            int code = 0;
            if (board[initialRow][initialCol] == 'Q')
            {
                bool canMovePrimaryDiagonal = initialRow + initialCol == targetRow + targetCol;
                bool canMoveVerticallyAndHorizontally = initialRow == targetRow || initialCol == targetCol;
                bool canMoveSecondaryDiagonal = targetRow - initialRow == targetCol - initialCol;
                if (canMovePrimaryDiagonal || canMoveVerticallyAndHorizontally || canMoveSecondaryDiagonal)
                {
                    if (IsInside(targetRow, targetCol))
                    {
                        board[initialRow][initialCol] = 'x';
                        board[targetRow][targetCol] = 'Q';
                    }
                    else
                    {
                        return 3;
                    }
                }
                else
                {
                    return 2;
                }
            }
            else
            {
                code = 1;
            }

            return code;
        }

        private static int MovePawn(int initialRow, int initialCol, int targetRow, int targetCol)
        {
            int code = 0;
            if (board[initialRow][initialCol] == 'P')
            {
                if (targetCol == initialCol && initialRow == targetRow + 1)
                {
                    if (IsInside(targetRow, targetCol))
                    {
                        board[initialRow][initialCol] = 'x';
                        board[targetRow][targetCol] = 'P';
                    }
                    else
                    {
                        return 3;
                    }
                }
                else
                {
                    return 2;
                }
            }
            else
            {
                code = 1;
            }

            return code;
        }

        private static bool IsInside(int row, int col)
        {
            return row >= 0 && row < board.Length && col >= 0 && col < board.Length;
        }

        private static void FillMatrix()
        {
            for (int row = 0; row < board.Length; row++)
            {
                board[row] = Console.ReadLine()
                    .Split(',', StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();
            }
        }
    }
}
