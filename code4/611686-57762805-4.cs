    class SomeOtherClass
    {
      private static Reminders reminder = new Reminders();
    
      // This operation is allowed,
      // since the compiler can guarantee that the referenced class member is already initialized
      // when this instance field initializer executes
      private dynamic defaultReminder = reminder.TimeSpanText[TimeSpan.FromMinutes(15)];
    }
