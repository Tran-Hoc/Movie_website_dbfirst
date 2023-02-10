using System;
namespace TestMovie
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            if (sum(2, 2) != 4)
            {
                throw new Exception();
            }

        }

        private int sum(int v1, int v2)
        {
            return v1 + v2;
        }
        

    }
}