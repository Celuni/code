    SQLiteConnection.CreateFile("MyDatabase.sqlite");
    m_dbConnection =
    new SQLiteConnection("Data Source=MyDatabase.sqlite;Version=3;");
    m_dbConnection.Open();
    string sql = "create table highscores (name varchar(20), score int)";
    SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
    command.ExecuteNonQuery();
    string sql = "insert into highscores (name, score) values ('Me', 9001)";
    SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
    command.ExecuteNonQuery();
    m_dbConnection.Close();
