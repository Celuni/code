            this.singleTap = true;
            await Task.Delay(200);
            if (this.singleTap)
            {
                  // Single tab Method .
            }
        }
        
        private void control_DoubleTapped_1(object sender, DoubleTappedRoutedEventArgs e)
        {
            this.singleTap = false;
            // Double tab Method  
      }
