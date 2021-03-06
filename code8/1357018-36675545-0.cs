    var result = list.Select(x => x.Split(",".ToCharArray(), 
                                   StringSplitOptions.RemoveEmptyEntries)) // now we have list of lists
					.Select(x => x.Select(y =>
					{
						int value;
						var isInt = int.TryParse(y, out value);
						return isInt ? value : (int?)null;
					})) // convert each element of inner list to null or its int values
					.Where(x => x.All(y => y.HasValue)) // only select lists which contains only integers
					.ToList();
