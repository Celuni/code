    private enum MyEnum { val1, val2, val3 }; //however this should be outside the method
    public void SomeMethod ()
    {
        var anonymousEnum= new { MyEnum.val1,MyEnum.val2};
    }
