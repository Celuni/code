    SessionOptions sessionOptions = new SessionOptions {
        Protocol = Protocol.Sftp,
        HostName = "example.com",
        UserName = "user",
        Password = "mypassword",
        SshHostKeyFingerprint = "ssh-rsa 2048 xx:xx:xx:xx:xx:xx..."
    };
    Session session = new Session();
    session.Open(sessionOptions);
