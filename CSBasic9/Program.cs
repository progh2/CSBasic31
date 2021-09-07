using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSBasic9
{
    class Program
    {

        class WrongBoxSizeException : Exception
        {
            public WrongBoxSizeException(string message) : base(message)
            {

            }
        }

        class Box
        {
            private int width;
            public int Width
            {
                get { return width;}
                set
                {
                    if(value > 0) { width = value;  }
                    else { throw new WrongBoxSizeException("너비는 양수를 입력하세요"); }
                }
            }
            private int height;
            public int Height
            {
                get { return height; }
                set
                {
                    if (value > 0) { height = value; }
                    else { throw new WrongBoxSizeException("높이는 양수를 입력하세요"); }
                }
            }
            public Box(int width, int height)
            {
                //this.width = width;
                Width = width;
                Height = height;
            }
            public int Area() { return this.width * this.height;  }
        }

        static void Main(string[] args)
        {

            Box b = new Box(10,10);
            //Box be = new Box(10, -10);
            //Box bz = new Box(0, 0);

            bool isFlag = true;
            while (isFlag)
            {
                Console.Write("입력: ");
                string input = Console.ReadLine();
                try
                {                    
                    int index = int.Parse(input);
                    if(index == 42)
                    {
                        throw new OverflowException(); // 강제 예외 발생
                    }
                    Console.WriteLine("입력 숫자: " + index);
                    isFlag = false;
                }
                catch (FormatException exception)
                {
                    Console.WriteLine("예외가 발생했습니다: 숫자를 아라비아 숫자로 넣어주세요!");
                }
                catch (OverflowException exception)
                {
                    Console.WriteLine("예외가 발생했습니다: " 
                        + int.MinValue + " ~ " + int.MaxValue + "사이 값을 입력해주세요");
                }
                catch (Exception exception)
                {
                    Console.WriteLine("예외가 발생했습니다.");
                    //return;
                    Console.WriteLine(exception.GetType());
                    Console.WriteLine(exception.Message);
                    Console.WriteLine(exception.StackTrace);
                }
                finally
                {
                    Console.WriteLine("-------");
                }
            }
        }
    }
}
