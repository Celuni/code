    using System.Threading;
    public partial class Form1
    { 
       private Timer _timer;
       private Dog _dog1, _dog2, _dog3, _dog4;
       public void InitializeComponent()
       {
          SetupDogs();
          _timer = new Timer(GameLoop, null, 
           TimeSpan.FromSeconds(1.0),
           TimeSpan.FromSeconds(1.0));
       }
       private void SetupDogs()
       {
          _dog1 = new Dog(PictureBoxDog1);
          _dog2 = new Dog(PictureBoxDog2);
          _dog3 = new Dog(PictureBoxDog3);
          _dog4 = new Dog(PictureBoxDog4);
       }
       public void GameLoop(object state)
       {
           GetUserInput();
           Update();
           Draw();
       }
       public void GetUserInput()
       {
         // e.g. if Last key 
         //   pressed  was arrow-left or 
         //   arrow-right etc.
       }
       public void Update()
       {
         _dog1.Update();
         _dog2.Update();
         _dog3.Update();
         _dog4.Update();
       }
       public void Draw()
       {
         _dog1.Draw();
         _dog2.Draw();
         _dog3.Draw();
         _dog4.Draw();
       }
    }
 
