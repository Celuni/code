      private void OnHardwareButtonsBackPressed(object sender, BackPressedEventArgs e)
      {
            // This is the missing line!
            e.Handled = true;
            // Close the App if you are on the startpage
            if (mMainFrame.CurrentSourcePageType == typeof(Startpage))
                App.Current.Exit();
            // Navigate back
            if (mMainFrame.CanGoBack)
            {
                mMainFrame.GoBack();
            }
      }
