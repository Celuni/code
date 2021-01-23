    <?xml version="1.0" encoding="utf-8"?>
    <CodeSnippets xmlns="http://schemas.microsoft.com/VisualStudio/2005/CodeSnippet">
      <CodeSnippet Format="1.0.0">
        <Header>
          <Title>Public Integer Property</Title>
          <Author>md5sum</Author>
          <Description>Creates a private integer member with a public integer property</Description>
          <HelpUrl />
          <SnippetTypes />
          <Keywords />
          <Shortcut>pi</Shortcut>
        </Header>
        <Snippet>
          <References />
          <Imports />
          <Declarations>
            <Literal Editable="true">
              <ID>varName</ID>
              <Type>int</Type>
              <ToolTip>The name of the variable.</ToolTip>
              <Default>VarName</Default>
              <Function />
            </Literal>
          </Declarations>
          <Code Language="csharp" Kind="method decl" Delimiter="$"><![CDATA[private int _$varName$
        public int $varName$
        {
            get
            {
                return _$varName$;
            }
            set
            {
                $varName$ = value;
            }
        }]]></Code>
        </Snippet>
      </CodeSnippet>
    </CodeSnippets>
