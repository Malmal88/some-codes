int[] nums = { 1, 5, 9, 4, 5, 6, 7, 8 };

for (int i = 1; i < nums.Length; i+=2)
{
    int temp = nums[i - 1];
    nums[i - 1] = nums[i];
    nums[i] = temp;
}
for(int i  = 0; i < nums.Length; i++) Console.WriteLine(nums[i]);
    