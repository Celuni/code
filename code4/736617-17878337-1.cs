    class Form1
    {
      public Form1()
      {
        ...
        Currency.RateChanged += RateChanged;
      }
    
      private void RateChanged(object source, EventArgs e)
      {
        labelRate = Currency.GetCurrency("USD").Rate;
      }
    }
    
    class Form2
    {
      void updateButtin_Click()
      {
        Currency.GetCurrency("USD").SetRate(decimal.Parse(rateTextBox.Rate);
      }  
    }
