
Random random = new Random();
int N=int.Parse(Console.ReadLine());
int [] nums = new int [N] ;
for (int i = 0; i < nums.Length; i++)
{
    nums[i] = random.Next(1, N);
    Console.Write($"  {nums[i]}");
}

while (true)
{
   bool f = false;
   for (int i = 1; i < nums.Length; i++)
   {
        int temp = nums[i-1];
        if (nums[i] < nums[i - 1])
        {
            f = true;
            nums[i-1]=nums[i];
            nums[i] = temp;

        }
   }
    if (!f) break;
}
Console.WriteLine();
for (int i = 0; i < nums.Length; i++) Console.Write($"  {nums[i]}");
