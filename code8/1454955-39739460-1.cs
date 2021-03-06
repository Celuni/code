    public string GetFirstNumber(string some_string) {
    
        StringBuilder sb = new StringBuilder();
        bool found = false;
        
        foreach(char c in some_string){
        	if(Char.IsDigit(c)){
        		sb.Append(c);
        		found = true;
        	} else if(found){
        		// If we have already found a digit, 
                // and current character is not a digit, stop looping
        		break;                
        	}
        }
    
        return sb.ToString();
    }
       
