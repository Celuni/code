    public void OnPointerClick(PointerEventData eventData)
    {
        if(Input.GetKeyDown(KeyCode.Mouse0)){
            DeselectAll(eventData);
            return; // <----
        }
        OnSelect(eventData);
    }
