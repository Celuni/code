    string[] AttributeTags =
        txtAttributeTags.Text.Split
        (
            new string[] { "," },
            StringSplitOptions.RemoveEmptyEntries
        );
    var newTags = AttributeTags.Except
    (
        attribute.AttributeTag,
        new CustomEqualityComparer<string>
        (
            (a, b) => 1,
            str => str.GetHashCode()
        )
    );
