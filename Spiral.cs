using System;

namespace SpiralMatrix
{
    class Spiral
    {
        int[,] matrix;
        int length;
        int size;
        int center;
        int num;
        int place;
        string input;
        bool flag;
        bool exit;

        static void Main(string[] args)
        {
            Console.WriteLine("Please enter an integer greater than zero, or type 'E' to exit:");
            Spiral sSpiral = new Spiral();
            if (!sSpiral.flag) sSpiral.buildMatrix(); 

            while (!sSpiral.exit)
            {
                Console.WriteLine("Please enter an integer greater than zero, or type 'E' to exit:");
                sSpiral = new Spiral();
                if (!sSpiral.flag) sSpiral.buildMatrix();
            }
        }
        
        public Spiral()
        {
            num = 0;
            flag = false;
            exit = false;
            getInput();
            length = Convert.ToInt32(Math.Floor(Math.Sqrt(size))) + 1;
            center = Convert.ToInt32(Math.Ceiling(length * .5)) - 1;
            place = center;
            matrix = new int[length, length];
        }

        private void getInput()
        {
            input = Convert.ToString(Console.ReadLine());
            
            if(Int32.TryParse(input, out this.size))
            {
                if (this.size <= 0) this.flag = true;
            }
            else if (input == "E")
            {
                this.exit = true;
            }
            else this.flag = true;

            if (this.flag) writeError();
            if (this.exit) Exit();
        }

        private void writeError()
        {
            Console.WriteLine("Input Error!");
        }

        private void Exit()
        {
            Console.WriteLine("Goodbye!");
            Environment.Exit(0);
        }

        public void buildMatrix()
        {
            for (int i = 0; i < length; i++)
                for (int j = 0; j < length; j++)
                    matrix[i, j] = 0;

            for (int edge = place + 2; place >= 0; edge += 1, place--)
                fillMatrix(place, place, edge);

            printMatrix();
        }
        
        private void fillMatrix(int x, int y, int upper)
        {
          int lower = (place == 0) ? -1 : place - 2;
          upper = (upper <= length) ? upper : length;

          for (int i = x; i < upper && matrix[y, i] == 0 && num <= size; i++)
          {
              matrix[y, i] = num++;
              x = i;
          }
          for (int i = y + 1; i < upper && matrix[i, x] == 0 && num <= size; ++i)
          {
              matrix[i, x] = num++;
              y = i;
          }
          for (int i = x - 1; i > lower && matrix[y, i] == 0 && num <= size; --i)
          {
              matrix[y, i] = num++;
              x = i;
          }
          for (int i = y - 1; i > lower + 1 && matrix[i, x] == 0 && num <= size; --i) matrix[i, x] = num++;

        }

        private void printMatrix()
        {
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    if ((matrix[i, j] != 0) || (i == center && j == center))
                    {
                        for (int pad = 4 - matrix[i, j].ToString().Length; pad > 0; pad--) Console.Write(" ");
                        Console.Write(matrix[i, j]);   
                    }
                    else Console.Write("    ");
                }
                Console.WriteLine();
            }
        }
    }
}
