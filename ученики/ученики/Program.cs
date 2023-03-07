internal class Program
{
    private static void Main(string[] args)
    {
        Random random = new Random();

        string[] name = { "Ваня", "Петя", "Коля", "Саша" };
        int[] height = new int[name.Length];
        int[] weight = new int[name.Length];
        float[] IMT = new float[name.Length];

        void Init()
        {
            for (int i = 0; i < name.Length; i++)
            {
                height[i] = random.Next(150, 200);
                weight[i] = random.Next(50, 100);
                IMT[i] = height[i] / (float)weight[i];
            }
        }

        static int  Calcmax(int[] data)
        {
            int max = 0;

            for (int i = 0; i < data.Length; i++)
            {
                if (data[max] < data[i]) max = i;
            }
            return max;
        }

        static int CalcmaxIMT(float[] data)
        {
            int max = 0;

            for (int i = 0; i < data.Length; i++)
            {
                if (data[max] < data[i]) max = i;
            }
            return max;
        }

        void Print()
        {
            for (int i = 0;i < height.Length;i++)
            {
                Console.WriteLine($"   {name[i]}");
                Console.WriteLine($" Рост {height[i]}");
                Console.WriteLine($" Вес  {weight[i]}");
                Console.WriteLine($" ИМТ  {IMT[i]}");
            }
         Console.WriteLine($" Самый высокий :{name[Calcmax(height)]};  Самый жирный: {name[Calcmax(weight)]}; Максимальный ИМТ:{name[CalcmaxIMT(IMT)]} ");
                       
        }

        Init();
        Print();
    }

}