    bool isPrime = true;
    StringBuilder sb = new StringBuilder();
        for (num1 = count1; num1 <= num2; num1++)
        {
            for (int j = 2; j <= 150; j++)
            {
                if (num1 != j && num1 % j == 0)
                {
                    isPrime = false;
                    break;
                }
            }
            if (isPrime)
            {
                sb.Append("" + num1 + "" + num1);
            }
            isPrime = true;
        }
    lblResult.Text = sb.ToString();
