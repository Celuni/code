        public int CommonCharacters(string s1, string s2)
        {
            bool[] matchedFlag = new bool[s2.Length];
            for (int i1 = 0; i1 < s1.Length; i1++)
            {
                for (int i2 = 0; i2 < s2.Length; i2++)
                {
                    if (s1.ToCharArray()[i1] == s2.ToCharArray()[i2] && !matchedFlag[i2])
                    {
                        matchedFlag[i2] = true;
                        break;
                    }
                }
            }
            return matchedFlag.ToList().Where(u => u).Count();
        }
