    class Sounds
    {
        SoundEffect sound;
        public Sounds(ContentManager content)
        {
            sound = content.Load<SoundEffect>("wavFileName");
        }
        public void PlaySound()
        {
        sound.Play();
        }
    }
