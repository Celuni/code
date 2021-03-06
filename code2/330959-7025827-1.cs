     private void button1_Click(object sender, EventArgs e) {
    
    // This will remove the radioboxes completely...
    _radioContainer.Controls.OfType<RadioButton>().ToList().ForEach(p => _radioContainer.Controls.Remove(p));
    
    // These will clear the checked state
    	_radioContainer.Controls.OfType<RadioButton>().ToList().ForEach(p => p.Checked = false);
        
    	foreach (RadioButton radio in _radioContainer.Controls.OfType<RadioButton>().ToList()) {
        				if (radio.Checked == true) {
        					radio.Checked = false;
        					break;
        				}
        			}
        		}
