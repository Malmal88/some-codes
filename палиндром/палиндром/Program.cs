
            bool ispalindrome = true;
            Console.WriteLine("Введите текст");

            string str = Console.ReadLine();

            for (int i = 0; i < str.Length/2; i++)
            {               
                 if (str[i] != str[str.Length-1-i]) 
                    {
                        ispalindrome = false;
                        break; 
                    }                                                   
            }
            if (ispalindrome) Console.WriteLine("палиндром");
            else Console.WriteLine("не палиндром");

