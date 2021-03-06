    //build list of random dates
    Random r = new Random();
    var dates = new List<DateTime>();
    for (int i = 0; i < 10; i++)
    {
        dates.Add(new DateTime(2014, r.Next(1,13), r.Next(1,28)));
    }
    //sort list
    dates.Sort();
 
    //get input
    string input = "1/13/14";
    DateTime inputDate = DateTime.Parse(input);
 	
    //find nearest
    var result = dates.BinarySearch(inputDate);
    DateTime nearest;
    if(result >= 0)
        nearest = dates[result];
    else
    {
        //if ~result is 1, then the input is the smallest element in the list, so the answer is element at 0
        //otherwise, check which difference is smaller
        nearest = (~result == 1) && 
            dates[~result].Subtract(inputDate) > dates[~result - 1].Subtract(inputDate)
                ? dates[~result - 1] 
                : dates[~result];
    }
